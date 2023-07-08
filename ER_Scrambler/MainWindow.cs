using Microsoft.WindowsAPICodePack.Dialogs;
using System.Configuration;
using SoulsFormats;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using static SoulsFormats.PARAM;

// Credit to TKGP for various snippets used throughout the program.
namespace ER_Scrambler
{
    public partial class MainWindow : Form
    {
        private CommonOpenFileDialog modPathDialog;
        private Mod currentMod;
        private Progress<string> progress;
        private IBinder? regulation;
        private bool regulation_encryption;
        public List<ParamWrapper> loadedParamWrappers;

        private List<PARAMDEF> paramdefs = new List<PARAMDEF>();

        public MainWindow()
        {
            InitializeComponent();

            progress = new Progress<string>(status => l_status.Text = status);
            regulation = null;
        }

        #region Interface
        private async void MainWindow_Load(object sender, EventArgs e)
        {
            modPathDialog = new CommonOpenFileDialog();
            modPathDialog.InitialDirectory = "";
            modPathDialog.IsFolderPicker = true;

            currentMod = new Mod("");

            t_ModPath.Text = "";
            c_Scramble_Bullet.Checked = true;
            c_Scramble_Weapon.Checked = true;
            c_Scramble_Rings.Checked = true;
            c_Scramble_Armor.Checked = true;
            c_Scramble_Spells.Checked = true;
            c_Scramble_Goods.Checked = true; 
            c_Scramble_Char.Checked = true;
            c_Scramble_Faces.Checked = true;

            BuildParamDefs();
        }

        private void b_SelectModPath_Click(object sender, EventArgs e)
        {
            if (modPathDialog.ShowDialog() == CommonFileDialogResult.Ok && !string.IsNullOrEmpty(modPathDialog.FileName))
            {
                currentMod.basePath = modPathDialog.FileName;
                t_ModPath.Text = currentMod.basePath;
            }
        }

        private async void b_Scramble_Click(object sender, EventArgs e)
        {
            currentMod.Scramble();

            ToggleControls(false);

            await Task.Run(() => Scramble(progress));

            ToggleControls(true);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Params
        private LoadParamsResult LoadParamResult(string target_path, bool isSecondary)
        {
            if (!File.Exists(target_path))
            {
                ShowError($"Regulation not found:\r\n{target_path}");
                return null;
            }

            var result = new LoadParamsResult();

            try
            {
                result.ParamBND = SFUtil.DecryptERRegulation(target_path);
                result.Encrypted = true;
            }
            catch (DllNotFoundException ex) when (ex.Message.Contains("oo2core_6_win64.dll"))
            {
                ShowError($"In order to load Sekiro params, you must copy oo2core_6_win64.dll from Sekiro into the lib folder.");

                return null;
            }
            catch (Exception ex)
            {
                ShowError($"Failed to load regulation:\r\n{target_path}\r\n\r\n{ex}");

                return null;
            }

            result.ParamWrappers = new List<ParamWrapper>();

            foreach (BinderFile file in result.ParamBND.Files.Where(f => f.Name.EndsWith(".param")))
            {
                string name = Path.GetFileNameWithoutExtension(file.Name);

                try
                {
                    PARAM param = PARAM.Read(file.Bytes);

                    if (param.ApplyParamdefCarefully(paramdefs))
                    {
                        var wrapper = new ParamWrapper(name, param, param.AppliedParamdef);
                        result.ParamWrappers.Add(wrapper);
                    }
                }
                catch (Exception ex)
                {
                    ShowError($"Failed to load param file: {name}.param\r\n\r\n{ex}");
                }
            }

            result.ParamWrappers.Sort();
            return result;
        }

        private void BuildParamDefs()
        {
            paramdefs.Clear();

            var paramdef_dir = GetParamdexDirectory("Defs");

            foreach (string path in Directory.GetFiles(paramdef_dir, "*.xml"))
            {
                string paramID = Path.GetFileNameWithoutExtension(path);

                try
                {
                    var paramdef = PARAMDEF.XmlDeserialize(path);

                    paramdefs.Add(paramdef);
                }
                catch (Exception ex)
                {
                    ShowError($"Failed to load paramdef {paramID}.txt\r\n\r\n{ex}");
                }
            }
        }

        public string GetParamdexDirectory(string subfolder)
        {
            if (subfolder == "")
                return $@"Assets\\Paramdex\\ER";
            else
                return $@"Assets\\Paramdex\\ER\\{subfolder}";
        }

        internal class LoadParamsResult
        {
            public bool Encrypted { get; set; }

            public IBinder ParamBND { get; set; }

            public List<ParamWrapper> ParamWrappers { get; set; }
        }

        private void Scramble(IProgress<string> progress)
        {
            // Load regulation
            progress.Report("Loading regulation.");

            if (currentMod.basePath == "")
            {
                progress.Report("Aborted.");
                MessageBox.Show("No base path specified.");
                return;
            }

            string regPath = Path.Combine(currentMod.scramblePath, "regulation.bin");
            if (!File.Exists(regPath))
            {
                progress.Report("Aborted.");
                ShowError($"Regulation file not found in game directory:\n{regPath}\nPlease make sure the path is correct.");
                return;
            }
            
            LoadParamsResult result = LoadParamResult(regPath, false);
            progress.Report("Regulation loaded.");

            regulation = result.ParamBND;
            regulation_encryption = result.Encrypted;
            loadedParamWrappers = result.ParamWrappers;
            
            // Scramble
            progress.Report("Scramble started.");

            try
            {
                Scrambler scrambler = new Scrambler(t_seed.Text, currentMod, loadedParamWrappers);

                // Bullet
                progress.Report("Scramble: Bullets");
                if (c_Scramble_Bullet.Checked)
                    loadedParamWrappers = scrambler.ScrambleBullet(c_Bullet_LimitedScramble.Checked, c_Bullet_AnyVFX.Checked, c_Bullet_AnySpEffect.Checked, c_Bullet_Spam.Checked);

                // EquipParamWeapon
                progress.Report("Scramble: Weapons");
                if (c_Scramble_Weapon.Checked)
                    loadedParamWrappers = scrambler.ScrambleEquipParamWeapon(c_Weapon_RestrictedScramble.Checked, c_Weapon_AnySpEffect.Checked, c_Weapon_AnyVFX.Checked);

                // EquipParamAccessory
                progress.Report("Scramble: Rings");
                if (c_Scramble_Rings.Checked)
                    loadedParamWrappers = scrambler.ScrambleEquipParamAccessory(c_Rings_RestrictedScramble.Checked, c_Rings_AnySpEffect.Checked);

                // EquipParamProtector
                progress.Report("Scramble: Armor");
                if (c_Scramble_Armor.Checked)
                    loadedParamWrappers = scrambler.ScrambleEquipParamProtector(c_Armor_LimitedScramble.Checked, c_Armor_AnySpEffect.Checked);

                // EquipParamGoods
                progress.Report("Scramble: Goods");
                if (c_Scramble_Goods.Checked)
                    loadedParamWrappers = scrambler.ScrambleEquipParamGoods(c_Goods_LimitedScramble.Checked, c_Goods_Skip_KeyItems.Checked);

                // Magic
                progress.Report("Scramble: Spells");
                if (c_Scramble_Spells.Checked)
                    loadedParamWrappers = scrambler.ScrambleMagic(c_Spell_LimitedScramble.Checked, c_Spell_AnyVFX.Checked);

                // Characters
                progress.Report("Scramble: Characters");
                if (c_Scramble_Char.Checked)
                    loadedParamWrappers = scrambler.ScrambleCharacters(c_Char_LimitedScramble.Checked, c_Char_IgnoreClasses.Checked);

                // Faces
                progress.Report("Scramble: Faces");
                if (c_Scramble_Faces.Checked)
                    loadedParamWrappers = scrambler.ScrambleFaces(c_Faces_LimitedScramble.Checked);

                // Assets
                progress.Report("Scramble: Assets");
                 loadedParamWrappers = scrambler.ScrambleAssets(c_Assets_LimitedScramble.Checked, c_Assets_AnyVFX.Checked, c_Assets_ScramblePickups.Checked);

            }
            catch (Exception ex)
            {
                progress.Report("Aborted.");
                ShowError($"Failed to scramble regulation file:\n{regPath}\n\n{ex}");
                return;
            }

            progress.Report("Scramble finished.");

            // Save regulation
            try
            {
                foreach (BinderFile file in regulation.Files)
                {
                    foreach (ParamWrapper wrapper in loadedParamWrappers)
                    {
                        ParamWrapper paramFile = wrapper;

                        if (Path.GetFileNameWithoutExtension(file.Name) == paramFile.Name)
                        {
                            try
                            {
                                file.Bytes = paramFile.Param.Write();
                            }
                            catch
                            {
                                ShowError($"Invalid data, failed to save {paramFile}. Data must be fixed before saving can complete.");
                                return;
                            }
                        }
                    }
                }

                SFUtil.EncryptERRegulation(regPath, regulation as BND4);
            }
            catch (Exception ex)
            {
                progress.Report("Aborted.");
                ShowError($"Failed to save regulation file:\n{regPath}\n\n{ex}");
                return;
            }

            SystemSounds.Asterisk.Play();

            progress.Report("Regulation saved.");
        }

        #endregion

        private void b_ToggleOn_Click(object sender, EventArgs e)
        {
            ToggleCheckboxes(true);
        }

        private void b_ToggleOff_Click(object sender, EventArgs e)
        {
            ToggleCheckboxes(false);
        }

        private void ToggleControls(bool state)
        {
            b_SelectModPath.Enabled = state;
            b_Scramble.Enabled = state;
            b_ToggleOff.Enabled = state;
            b_ToggleOn.Enabled = state;

            // Bullet
            c_Scramble_Bullet.Enabled = state;
            c_Bullet_LimitedScramble.Enabled = state;
            c_Bullet_AnyVFX.Enabled = state;
            c_Bullet_AnySpEffect.Enabled = state;
            c_Bullet_Spam.Enabled = state;

            // Weapon
            c_Scramble_Weapon.Enabled = state;
            c_Weapon_AnySpEffect.Enabled = state;
            c_Weapon_AnyVFX.Enabled = state;
            c_Weapon_RestrictedScramble.Enabled = state;

            // Rings
            c_Scramble_Rings.Enabled = state;
            c_Rings_AnySpEffect.Enabled = state;
            c_Rings_RestrictedScramble.Enabled = state;

            // Armor
            c_Scramble_Armor.Enabled = state;
            c_Armor_AnySpEffect.Enabled = state;
            c_Armor_LimitedScramble.Enabled = state;

            // Spells
            c_Scramble_Spells.Enabled = state;
            c_Spell_AnyVFX.Enabled = state;
            c_Spell_LimitedScramble.Enabled = state;

            // Goods
            c_Scramble_Goods.Enabled = state;
            c_Goods_LimitedScramble.Enabled = state;
            c_Goods_Skip_KeyItems.Enabled = state;

            // Characters
            c_Scramble_Char.Enabled = state;
            c_Char_LimitedScramble.Enabled = state;
            c_Char_IgnoreClasses.Enabled = state;

            // Faces
            c_Scramble_Faces.Enabled = state;
            c_Faces_LimitedScramble.Enabled = state;

            // Misc
            c_Scramble_AssetParam.Enabled = state;
            c_Assets_AnyVFX.Enabled = state;
            c_Assets_LimitedScramble.Enabled = state;
            c_Assets_ScramblePickups.Enabled = state;
        }

        private void ToggleCheckboxes(bool state)
        {
            // Bullet
            c_Scramble_Bullet.Checked = state;
            c_Bullet_LimitedScramble.Checked = state;
            c_Bullet_AnyVFX.Checked = state;
            c_Bullet_AnySpEffect.Checked = state;
            c_Bullet_Spam.Checked = state;

            // Weapon
            c_Scramble_Weapon.Checked = state;
            c_Weapon_AnySpEffect.Checked = state;
            c_Weapon_AnyVFX.Checked = state;
            c_Weapon_RestrictedScramble.Checked = state;

            // Rings
            c_Scramble_Rings.Checked = state;
            c_Rings_AnySpEffect.Checked = state;
            c_Rings_RestrictedScramble.Checked = state;

            // Armor
            c_Scramble_Armor.Checked = state;
            c_Armor_AnySpEffect.Checked = state;
            c_Armor_LimitedScramble.Checked = state;

            // Spells
            c_Scramble_Spells.Checked = state;
            c_Spell_AnyVFX.Checked = state;
            c_Spell_LimitedScramble.Checked = state;

            // Goods
            c_Scramble_Goods.Checked = state;
            c_Goods_LimitedScramble.Checked = state;
            c_Goods_Skip_KeyItems.Checked = state;

            // Characters
            c_Scramble_Char.Checked = state;
            c_Char_LimitedScramble.Checked = state;
            c_Char_IgnoreClasses.Checked = state;

            // Faces
            c_Scramble_Faces.Checked = state;
            c_Faces_LimitedScramble.Checked = state;

            // Misc
            c_Scramble_AssetParam.Checked = state;
            c_Assets_AnyVFX.Checked = state;
            c_Assets_LimitedScramble.Checked = state;
            c_Assets_ScramblePickups.Checked = state;
        }
    }
}