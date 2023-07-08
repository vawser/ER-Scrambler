
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using SoulsFormats;
using System.Xml.Linq;
using static SoulsFormats.PARAM;
using System.Configuration;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using YamlDotNet.Core.Tokens;
using System.Text.RegularExpressions;
using static SoulsFormats.PARAMDEF;
using System.Windows.Documents;

namespace ER_Scrambler
{
    static class Extensions
    {
        public static T GetRandom<T>(this List<T> list, Random rand)
        {
            return list[rand.Next(list.Count)];
        }

        public static T PopRandom<T>(this List<T> list, Random rand)
        {
            int index = rand.Next(list.Count);
            T result = list[index];
            list.RemoveAt(index);
            return result;
        }

        public static Match RegexMatch(this string input, string pattern, RegexOptions regexOptions = RegexOptions.IgnoreCase)
        {
            return Regex.Match(input, pattern, regexOptions);
        }
    }

    public class Scrambler
    {
        private readonly Random rand;
        public static List<ParamWrapper> loadedParamWrappers { get; set; }

        public ParamWrapper atkParam;
        public ParamWrapper atkNpcParam;
        public ParamWrapper bulletParam;
        public ParamWrapper speffectParam;
        public ParamWrapper itemlotMapParam;
        public ParamWrapper itemlotEnemyParam;

        public List<string> VFX_ID_List;

        public string fieldListPath = AppContext.BaseDirectory + "\\Assets\\Field Lists\\";
        public string referenceListPath = AppContext.BaseDirectory + "\\Assets\\Reference Lists\\";

        private static byte[] weaponCategory_List = { 0, 1, 2, 3, 4, 5, 6, 7, 9, 12 };
        private static byte[] bowCategory_List = { 10, 11 };
        private static byte[] catalystCategory_List = { 8 };

        public List<string> Bullet_Limited_Scramble;
        public List<string> Weapons_Limited_Scramble;
        public List<string> Weapons_Moveset_Scramble;
        public List<string> Rings_Limited_Scramble;
        public List<string> Armor_Limited_Scramble;
        public List<string> Spell_Limited_Scramble;
        public List<string> Goods_Limited_Scramble;
        public List<string> Characters_Limited_Scramble;
        public List<string> Faces_Limited_Scramble;
        public List<string> Assets_Limited_Scramble;

        #region Scramble - Core
        public Scrambler(string seed, Mod current_mod, List<ParamWrapper> paramWrappers)
        {
            loadedParamWrappers = paramWrappers;

            if (seed == string.Empty)
                rand = new Random();
            else
                rand = new Random(seed.GetHashCode());

            // Build reference wrappers
            foreach (ParamWrapper wrapper in loadedParamWrappers)
            {
                if (wrapper.Name == "AtkParam_Pc")
                {
                    atkParam = wrapper;
                }
                if (wrapper.Name == "AtkParam_Npc")
                {
                    atkNpcParam = wrapper;
                }
                if (wrapper.Name == "Bullet")
                {
                    bulletParam = wrapper;
                }
                if (wrapper.Name == "SpEffectParam")
                {
                    speffectParam = wrapper;
                }
                if (wrapper.Name == "ItemLotParam_map")
                {
                    itemlotMapParam = wrapper;
                }
                if (wrapper.Name == "ItemLotParam_enemy")
                {
                    itemlotEnemyParam = wrapper;
                }
            }

            // Build scramble lists 
            VFX_ID_List = BuildScrambleList(referenceListPath + "\\VFX_List.txt");
            Bullet_Limited_Scramble = BuildScrambleList(fieldListPath + "\\Bullets\\Limited_Scramble.txt");
            Weapons_Limited_Scramble = BuildScrambleList(fieldListPath + "\\Weapons\\Limited_Scramble.txt");
            Weapons_Moveset_Scramble = BuildScrambleList(fieldListPath + "\\Weapons\\Moveset_Scramble.txt");
            Rings_Limited_Scramble = BuildScrambleList(fieldListPath + "\\Rings\\Limited_Scramble.txt");
            Armor_Limited_Scramble = BuildScrambleList(fieldListPath + "\\Armor\\Limited_Scramble.txt");
            Spell_Limited_Scramble = BuildScrambleList(fieldListPath + "\\Spells\\Limited_Scramble.txt");
            Goods_Limited_Scramble = BuildScrambleList(fieldListPath + "\\Goods\\Limited_Scramble.txt");
            Characters_Limited_Scramble = BuildScrambleList(fieldListPath + "\\Characters\\Limited_Scramble.txt");
            Faces_Limited_Scramble = BuildScrambleList(fieldListPath + "\\Faces\\Limited_Scramble.txt");
            Assets_Limited_Scramble = BuildScrambleList(fieldListPath + "\\Assets\\Limited_Scramble.txt");
        }

        private List<string> BuildScrambleList(string path)
        {
            List<string> list = new List<string>();

            foreach (string line in File.ReadLines(path, Encoding.UTF8))
            {
                list.Add(line);
            }

            return list;
        }
        #endregion

        #region Scramble - Bullet
        public List<ParamWrapper> ScrambleBullet(bool useLimitedScramble, bool useAnyVFX, bool useAnySpEffect, bool useSpam)
        {
            foreach (ParamWrapper wrapper in loadedParamWrappers)
            {
                if (wrapper.Name == "Bullet")
                {
                    PARAM param = wrapper.Param;
                    var param_rows = param.Rows;

                    if (useLimitedScramble)
                    {
                        RandomizeFromList(param_rows, Bullet_Limited_Scramble);
                    }
                    else
                    {
                        if (useSpam)
                        {
                            RandomizeAll(param_rows, true);
                        }
                        else
                        {
                            RandomizeAll(param_rows);
                        }
                    }

                    foreach (PARAM.Row row in param_rows)
                    {
                        foreach (PARAM.Cell cell in row.Cells)
                        {
                            string cType = cell.Def.DisplayType.ToString();
                            string cName = cell.Def.InternalName;

                            // Use any VFX
                            if (useAnyVFX)
                            {
                                if (cName == "sfxId_Bullet")
                                {
                                    var index = rand.Next(VFX_ID_List.Count);
                                    var randomItem = VFX_ID_List[index];

                                    cell.Value = int.Parse(randomItem);
                                }
                                if (cName == "sfxId_Hit")
                                {
                                    var index = rand.Next(VFX_ID_List.Count);
                                    var randomItem = VFX_ID_List[index];

                                    cell.Value = int.Parse(randomItem);
                                }
                                if (cName == "sfxId_Flick")
                                {
                                    // Apply 10% of the time
                                    if (rand.Next(11) > 9)
                                    {
                                        var index = rand.Next(VFX_ID_List.Count);
                                        var randomItem = VFX_ID_List[index];

                                        cell.Value = int.Parse(randomItem);
                                    }
                                }
                            }

                            // Use any SpEffect
                            if(useAnySpEffect)
                            {
                                // Add 10% of the time
                                if (rand.Next(100) < 10)
                                {
                                    if (cName == "spEffectIDForShooter")
                                    {
                                        var index = rand.Next(speffectParam.Rows.Count);
                                        var randomItem = speffectParam.Rows[index];

                                        cell.Value = randomItem.ID;
                                    }
                                }

                                // Add 10% of the time
                                if (rand.Next(100) < 10)
                                {
                                    if (cName == "spEffectId0")
                                    {
                                        var index = rand.Next(speffectParam.Rows.Count);
                                        var randomItem = speffectParam.Rows[index];

                                        cell.Value = randomItem.ID;
                                    }
                                }

                                // Add 5% of the time
                                if (rand.Next(100) < 5)
                                {
                                    if (cName == "spEffectId1" ||
                                        cName == "spEffectId2" ||
                                        cName == "spEffectId3" ||
                                        cName == "spEffectId4")
                                    {
                                        var index = rand.Next(speffectParam.Rows.Count);
                                        var randomItem = speffectParam.Rows[index];

                                        cell.Value = randomItem.ID;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return loadedParamWrappers;
        }
        #endregion

        #region Scramble - EquipParamWeapon
        public List<ParamWrapper> ScrambleEquipParamWeapon(bool useLimitedScramble, bool useAnySpEffect, bool useAnyVFX)
        {
            foreach (ParamWrapper wrapper in loadedParamWrappers)
            {
                if (wrapper.Name == "EquipParamWeapon")
                {
                    PARAM param = wrapper.Param;
                    var param_rows = param.Rows.Where(
                        row => row.ID >= 1000000 && row.ID < 60000000
                    );

                    if (useLimitedScramble)
                    {
                        RandomizeFromList(param_rows, Weapons_Limited_Scramble);
                    }
                    else
                    {
                        RandomizeAllExceptList(param_rows, Weapons_Moveset_Scramble);
                    }

                    var weapons = param_rows.Where(row => weaponCategory_List.Contains((byte)row["weaponCategory"].Value));
                    RandomizeFromList(weapons, Weapons_Moveset_Scramble);

                    var bows = param_rows.Where(row => bowCategory_List.Contains((byte)row["weaponCategory"].Value));
                    RandomizeFromList(weapons, Weapons_Moveset_Scramble);

                    var catalysts = param_rows.Where(row => catalystCategory_List.Contains((byte)row["weaponCategory"].Value));
                    RandomizeFromList(weapons, Weapons_Moveset_Scramble);

                    foreach (PARAM.Row row in param_rows)
                    {
                        bool hasVFXSet = false;

                        foreach (PARAM.Cell cell in row.Cells)
                        {
                            string cType = cell.Def.DisplayType.ToString();
                            string cName = cell.Def.InternalName;

                            // Allow any VFX in the valid VFX fields, correct dummy poly if set
                            if (useAnyVFX)
                            {
                                // Add 25% of the time
                                if (rand.Next(100) < 25)
                                {
                                    if (cName == "residentSfxId_1")
                                    {
                                        var index = rand.Next(VFX_ID_List.Count);
                                        var randomItem = VFX_ID_List[index];

                                        cell.Value = int.Parse(randomItem);

                                        hasVFXSet = true;
                                    }
                                }

                                if (hasVFXSet)
                                {
                                    if (cName == "residentSfx_DmyId_1")
                                    {
                                        cell.Value = 100;
                                    }
                                }
                            }

                            // Allow any SpEffect to be added to valid SpEffect fields
                            if (useAnySpEffect)
                            {
                                // Add 25% of the time
                                if (rand.Next(100) < 25)
                                {
                                    if (cName == "spEffectBehaviorId0" ||
                                        cName == "spEffectBehaviorId1" ||
                                        cName == "spEffectBehaviorId2")
                                    {
                                        var index = rand.Next(speffectParam.Rows.Count);
                                        var randomItem = speffectParam.Rows[index];

                                        cell.Value = randomItem.ID;
                                    }
                                }

                                // Add 25% of the time
                                if (rand.Next(100) < 25)
                                {
                                    if (cName == "residentSpEffectId" ||
                                        cName == "residentSpEffectId1" ||
                                        cName == "residentSpEffectId2")
                                    {
                                        var index = rand.Next(speffectParam.Rows.Count);
                                        var randomItem = speffectParam.Rows[index];

                                        cell.Value = randomItem.ID;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return loadedParamWrappers;
        }
        #endregion

        #region Scramble - EquipParamAccessory
        public List<ParamWrapper> ScrambleEquipParamAccessory(bool useLimitedScramble, bool useAnySpEffect)
        {
            foreach (ParamWrapper wrapper in loadedParamWrappers)
            {
                if (wrapper.Name == "EquipParamAccessory")
                {
                    if (useLimitedScramble)
                    {
                        RandomizeFromList(wrapper.Rows, Rings_Limited_Scramble);
                    }
                    else
                    {
                        RandomizeAll(wrapper.Rows);
                    }

                    // Allow any SpEffect to be added to valid SpEffect fields
                    if(useAnySpEffect)
                    {
                        foreach (PARAM.Row row in wrapper.Rows)
                        {
                            foreach (PARAM.Cell cell in row.Cells)
                            {
                                string cType = cell.Def.DisplayType.ToString();
                                string cName = cell.Def.InternalName;

                                if (cName == "refId")
                                {
                                    var index = rand.Next(speffectParam.Rows.Count);
                                    var randomItem = speffectParam.Rows[index];

                                    cell.Value = randomItem.ID;
                                }

                                // Add 10% of the time
                                if (rand.Next(100) < 10)
                                {
                                    if (cName == "residentSpEffectId1" ||
                                        cName == "residentSpEffectId2" ||
                                        cName == "residentSpEffectId3" ||
                                        cName == "residentSpEffectId4")
                                    {
                                        var index = rand.Next(speffectParam.Rows.Count);
                                        var randomItem = speffectParam.Rows[index];

                                        cell.Value = randomItem.ID;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return loadedParamWrappers;
        }
        #endregion

        #region Scramble - EquipParamProtector
        public List<ParamWrapper> ScrambleEquipParamProtector(bool useLimitedScramble, bool useAnySpEffect)
        {
            List<string> field = new List<string> { "equipModelId" };

            foreach (ParamWrapper wrapper in loadedParamWrappers)
            {
                if (wrapper.Name == "EquipParamProtector")
                {
                    PARAM param = wrapper.Param;

                    var param_rows = param.Rows.Where(
                        row => row.ID >= 40000
                    );

                    if (useLimitedScramble)
                    {
                        RandomizeFromList(param_rows, Armor_Limited_Scramble);
                    }
                    else
                    {
                        RandomizeAllExceptList(param_rows, field);
                    }

                    // Scramble equip models
                    var head_armor = param.Rows.Where(row => (byte)row["headEquip"].Value == 1);
                    RandomizeFromList(head_armor, field);

                    var body_armor = param.Rows.Where(row => (byte)row["bodyEquip"].Value == 1);
                    RandomizeFromList(body_armor, field);

                    var arm_armor = param.Rows.Where(row => (byte)row["armEquip"].Value == 1);
                    RandomizeFromList(arm_armor, field);

                    var leg_armor = param.Rows.Where(row => (byte)row["legEquip"].Value == 1);
                    RandomizeFromList(leg_armor, field);

                    // Allow any SpEffect to be added to valid SpEffect fields
                    if (useAnySpEffect)
                    {
                        foreach (PARAM.Row row in param_rows)
                        {
                            foreach (PARAM.Cell cell in row.Cells)
                            {
                                string cType = cell.Def.DisplayType.ToString();
                                string cName = cell.Def.InternalName;

                                // Add 25% of the time
                                if (rand.Next(100) < 25)
                                {
                                    if (cName == "residentSpEffectId" ||
                                        cName == "residentSpEffectId2" ||
                                        cName == "residentSpEffectId3")
                                    {
                                        var index = rand.Next(speffectParam.Rows.Count);
                                        var randomItem = speffectParam.Rows[index];

                                        cell.Value = randomItem.ID;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return loadedParamWrappers;
        }
        #endregion

        #region Scramble - Magic
        public List<ParamWrapper> ScrambleMagic(bool useLimitedScramble, bool useAnyVFX)
        {
            foreach (ParamWrapper wrapper in loadedParamWrappers)
            {
                PARAM param = wrapper.Param;
                var param_rows = param.Rows;

                if (wrapper.Name == "Magic")
                {
                    if (useLimitedScramble)
                    {
                        RandomizeFromList(param_rows, Spell_Limited_Scramble);

                        RandomizeTriple<int, byte, byte>(param.Rows, "refId1", "refCategory1", "consumeType1");
                        RandomizeTriple<int, byte, byte>(param.Rows, "refId2", "refCategory2", "consumeType2");
                        RandomizeTriple<int, byte, byte>(param.Rows, "refId3", "refCategory3", "consumeType3");
                        RandomizeTriple<int, byte, byte>(param.Rows, "refId4", "refCategory4", "consumeType4");
                        RandomizeTriple<int, byte, byte>(param.Rows, "refId5", "refCategory5", "consumeType5");
                        RandomizeTriple<int, byte, byte>(param.Rows, "refId6", "refCategory6", "consumeType6");
                        RandomizeTriple<int, byte, byte>(param.Rows, "refId7", "refCategory7", "consumeType7");
                        RandomizeTriple<int, byte, byte>(param.Rows, "refId8", "refCategory8", "consumeType8");
                        RandomizeTriple<int, byte, byte>(param.Rows, "refId9", "refCategory9", "consumeType9");
                        RandomizeTriple<int, byte, byte>(param.Rows, "refId10", "refCategory10", "consumeType10");
                    }
                    else
                    {
                        RandomizeAll(param_rows);
                    }

                    // Allow any SpEffect to be added to valid SpEffect fields
                    if (useAnyVFX)
                    {
                        foreach (PARAM.Row row in param_rows)
                        {
                            foreach (PARAM.Cell cell in row.Cells)
                            {
                                string cType = cell.Def.DisplayType.ToString();
                                string cName = cell.Def.InternalName;

                                // Use any VFX
                                if (useAnyVFX)
                                {
                                    if (cName == "castSfxId")
                                    {
                                        var index = rand.Next(VFX_ID_List.Count);
                                        var randomItem = VFX_ID_List[index];

                                        cell.Value = int.Parse(randomItem);
                                    }
                                    if (cName == "fireSfxId")
                                    {
                                        var index = rand.Next(VFX_ID_List.Count);
                                        var randomItem = VFX_ID_List[index];

                                        cell.Value = int.Parse(randomItem);
                                    }
                                    if (cName == "effectSfxId")
                                    {
                                        // Apply 20% of the time
                                        if (rand.Next(100) < 20)
                                        {
                                            var index = rand.Next(VFX_ID_List.Count);
                                            var randomItem = VFX_ID_List[index];

                                            cell.Value = int.Parse(randomItem);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return loadedParamWrappers;
        }
        #endregion

        #region Scramble - Assets
        public List<ParamWrapper> ScrambleAssets(bool useLimitedScramble, bool useAnyVFX, bool scramblePickups)
        {
            foreach (ParamWrapper wrapper in loadedParamWrappers)
            {
                if (wrapper.Name == "AssetEnvironmentGeometryParam")
                {
                    PARAM param = wrapper.Param;
                    var param_rows = param.Rows;

                    if (useLimitedScramble)
                    {
                        RandomizeFromList(param_rows, Assets_Limited_Scramble);
                    }
                    else
                    {
                        RandomizeAll(param_rows);
                    }

                    foreach (PARAM.Row row in param_rows)
                    {
                        foreach (PARAM.Cell cell in row.Cells)
                        {
                            string cType = cell.Def.DisplayType.ToString();
                            string cName = cell.Def.InternalName;

                            // Use any VFX
                            if (useAnyVFX)
                            {
                                List<string> sfxFields = new List<string> {
                                    "breakSfxId",
                                    "breakLandingSfxId",
                                    "breakLandingSfxId",
                                    "burnSfxId_1",
                                    "burnSfxId_2",
                                    "burnSfxId_3"
                                };

                                foreach (string name in sfxFields)
                                {
                                    if (cName == name)
                                    {
                                        var index = rand.Next(VFX_ID_List.Count);
                                        var randomItem = VFX_ID_List[index];

                                        cell.Value = int.Parse(randomItem);
                                    }
                                }
                            }

                            // Scramble pickups
                            if(scramblePickups)
                            {
                                List<string> itemlotFields = new List<string> {
                                    "breakItemLotParamId",
                                    "pickUpItemLotParamId",
                                    "pickUpReplacementItemLotParamId",
                                    "repickItemLotParamId",
                                    "repickReplacementItemLotParamId"
                                };

                                foreach (string name in itemlotFields)
                                {
                                    if (cName == name)
                                    {
                                        var index = rand.Next(itemlotMapParam.Rows.Count);
                                        var randomItem = itemlotMapParam.Rows[index];

                                        cell.Value = randomItem.ID;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return loadedParamWrappers;
        }
        #endregion

        #region Scramble - EquipParamGoods
        public List<ParamWrapper> ScrambleEquipParamGoods(bool useLimitedScramble, bool ignoreKeyItems)
        {
            foreach (ParamWrapper wrapper in loadedParamWrappers)
            {
                if (wrapper.Name == "EquipParamGoods")
                {
                    PARAM param = wrapper.Param;

                    // Ignore test data
                    var param_rows = param.Rows.Where(row => row.ID >= 99);

                    if (ignoreKeyItems)
                        param_rows = param.Rows.Where(row => (byte)row["goodsType"].Value == 0 && ((row.ID >= 251 && row.ID <= 999) || (row.ID >= 1100)));

                    if (useLimitedScramble)
                    {
                        RandomizeFromList(param_rows, Goods_Limited_Scramble);
                        RandomizePair<byte, int>(param_rows, "refCategory", "refId_default");
                    }
                    else
                    {
                        RandomizeAll(param_rows);
                    }
                }
            }

            return loadedParamWrappers;
        }
        #endregion

        #region Scramble - Characters
        public List<ParamWrapper> ScrambleCharacters(bool useLimitedScramble, bool ignorePlayerClasses)
        {
            foreach (ParamWrapper wrapper in loadedParamWrappers)
            {
                if (wrapper.Name == "CharaInitParam")
                {
                    PARAM param = wrapper.Param;
                    var param_rows = param.Rows;

                    if (ignorePlayerClasses)
                        param_rows = param.Rows.Where(row => row.ID >= 4000).ToList();

                    if (useLimitedScramble)
                    {
                        RandomizeFromList(param_rows, Characters_Limited_Scramble);
                    }
                    else
                    {
                        RandomizeAll(param_rows);
                    }
                }
            }

            return loadedParamWrappers;
        }
        #endregion

        #region Scramble - Faces
        public List<ParamWrapper> ScrambleFaces(bool useLimitedScramble)
        {
            foreach (ParamWrapper wrapper in loadedParamWrappers)
            {
                if (wrapper.Name == "FaceParam")
                {
                    PARAM param = wrapper.Param;
                    var param_rows = param.Rows;

                    if (useLimitedScramble)
                    {
                        RandomizeFromList(param_rows, Faces_Limited_Scramble);
                    }
                    else
                    {
                        RandomizeAll(param_rows);
                    }
                }
            }

            return loadedParamWrappers;
        }
        #endregion

        #region Util
        private void RandomizeOne<T>(IEnumerable<PARAM.Row> rows, string param, bool plusMode = false)
        {
            if (plusMode)
            {
                List<T> options = rows.Select(row => (T)row[param].Value).GroupBy(val => val).Select(group => group.First()).ToList();
                foreach (PARAM.Row row in rows)
                    row[param].Value = options.GetRandom(rand);
            }
            else
            {
                List<T> options = rows.Select(row => (T)row[param].Value).ToList();
                foreach (PARAM.Row row in rows)
                    row[param].Value = options.PopRandom(rand);
            }
        }

        private void RandomizePair<T1, T2>(IEnumerable<PARAM.Row> rows, string param1, string param2)
        {
            List<(T1, T2)> options = rows.Select(row => ((T1)row[param1].Value, (T2)row[param2].Value)).ToList();
            foreach (PARAM.Row row in rows)
            {
                (T1 val1, T2 val2) = options.PopRandom(rand);
                row[param1].Value = val1;
                row[param2].Value = val2;
            }
        }

        private void RandomizeTriple<T1, T2, T3>(IEnumerable<PARAM.Row> rows, string param1, string param2, string param3)
        {
            List<(T1, T2, T3)> options = rows.Select(row => ((T1)row[param1].Value, (T2)row[param2].Value, (T3)row[param3].Value)).ToList();
            foreach (PARAM.Row row in rows)
            {
                (T1 val1, T2 val2, T3 val3) = options.PopRandom(rand);
                row[param1].Value = val1;
                row[param2].Value = val2;
                row[param3].Value = val3;
            }
        }

        private void RandomizeAllExceptList(IEnumerable<PARAM.Row> rows, List<string> valid_fields)
        {
            foreach (PARAM.Cell cell in rows.First().Cells)
            {
                string cType = cell.Def.DisplayType.ToString();
                string cName = cell.Def.InternalName;

                bool modify = true;

                foreach (string field in valid_fields)
                {
                    if (cName == field)
                    {
                        modify = false;
                    }
                }

                if(modify)
                {
                    if (cType == "u8" || cType == "x8")
                        RandomizeOne<byte>(rows, cName);
                    else if (cType == "s8")
                        RandomizeOne<sbyte>(rows, cName);
                    else if (cType == "u16" || cType == "x16")
                        RandomizeOne<ushort>(rows, cName);
                    else if (cType == "s16")
                        RandomizeOne<short>(rows, cName);
                    else if (cType == "u32" || cType == "x32")
                        RandomizeOne<uint>(rows, cName);
                    else if (cType == "s32")
                        RandomizeOne<int>(rows, cName);
                    else if (cType == "f32")
                        RandomizeOne<float>(rows, cName);
                    else if (cType == "b8" || cType == "b32")
                        RandomizeOne<bool>(rows, cName);
                    else if (cType == "dummy8" || cType == "fixstr" || cType == "fixstrW")
                        Console.WriteLine($"Skipped {cName}");
                    else
                        throw null;
                }
            }
        }

        private void RandomizeFromList(IEnumerable<PARAM.Row> rows, List<string> valid_fields)
        {
            foreach (PARAM.Cell cell in rows.First().Cells)
            {
                string cType = cell.Def.DisplayType.ToString();
                string cName = cell.Def.InternalName;

                foreach (string field in valid_fields)
                {
                    if (cName == field)
                    {
                        if (cType == "u8" || cType == "x8")
                            RandomizeOne<byte>(rows, cName);
                        else if (cType == "s8")
                            RandomizeOne<sbyte>(rows, cName);
                        else if (cType == "u16" || cType == "x16")
                            RandomizeOne<ushort>(rows, cName);
                        else if (cType == "s16")
                            RandomizeOne<short>(rows, cName);
                        else if (cType == "u32" || cType == "x32")
                            RandomizeOne<uint>(rows, cName);
                        else if (cType == "s32")
                            RandomizeOne<int>(rows, cName);
                        else if (cType == "f32")
                            RandomizeOne<float>(rows, cName);
                        else if (cType == "b8" || cType == "b32")
                            RandomizeOne<bool>(rows, cName);
                        else if (cType == "dummy8" || cType == "fixstr" || cType == "fixstrW")
                            Console.WriteLine($"Skipped {cName}");
                        else
                            throw null;
                    }
                }
            }
        }

        private void RandomizeAll(IEnumerable<PARAM.Row> rows, bool plusMode = false)
        {
            foreach (PARAM.Cell cell in rows.First().Cells)
            {
                string cType = cell.Def.DisplayType.ToString();
                string cName = cell.Def.InternalName;

                //Console.WriteLine($"{cName} - {cType}");

                if (cType == "u8" || cType == "x8")
                    RandomizeOne<byte>(rows, cName, plusMode);
                else if (cType == "s8")
                    RandomizeOne<sbyte>(rows, cName, plusMode);
                else if (cType == "u16" || cType == "x16")
                    RandomizeOne<ushort>(rows, cName, plusMode);
                else if (cType == "s16")
                    RandomizeOne<short>(rows, cName, plusMode);
                else if (cType == "u32" || cType == "x32")
                    RandomizeOne<uint>(rows, cName, plusMode);
                else if (cType == "s32")
                    RandomizeOne<int>(rows, cName, plusMode);
                else if (cType == "f32")
                    RandomizeOne<float>(rows, cName, plusMode);
                else if (cType == "b8" || cType == "b32")
                    RandomizeOne<bool>(rows, cName, plusMode);
                else if (cType == "dummy8" || cType == "fixstr" || cType == "fixstrW")
                    Console.WriteLine($"Skipped {cName}");
                else
                    throw null;
            }
        }
        #endregion
    }
}
