using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Items
{

    public int id;
    public string itemName, description;
   
    public Sprite sprite;
    /// <summary>
    /// Select the type of item
    /// 0-Weapon ; 1-Armor ; 2-Acessory ; 3-Consumable ; 4-Other
    /// </summary>
    public int type = -1;
    public int _size;
    //public float durability;   
    //int att change

    public void Load()
    {
        
        _size = Resources.LoadAll<Sprite>("RandomItems").Length;

        if (id > -1)
        {

            sprite = Resources.LoadAll<Sprite>("RandomItems")[id];
            try
            {

                switch (id)
                {
                    #region 0-25
                    case 0:
                        itemName = "Devil's Axe";
                        description = "An axe corrupted by the devils himself.";
                        type = 0;
                        break;
                    case 1:
                        itemName = "Oak Staff";
                        description = "A proper use of a old oak.";
                        type = 0;
                        break;
                    case 2:
                        itemName = "Crystal Bow";
                        description = "A fine bow made from a high quality crystal.";
                        type = 0;
                        break;
                    case 3:
                        itemName = "Spear";
                        description = "An iron spear.";
                        type = 0;
                        break;
                    case 4:
                        itemName = "Double Guard Sword";
                        description = "A good sword for defense.";
                        type = 0;
                        break;
                    case 5:
                        itemName = "Crunch Mace";
                        description = "A mace with a name made from the sounds when it meet his enemies.";
                        type = 0;
                        break;
                    case 6:
                        itemName = "Layered Sword";
                        description = "A sword made of layers.";
                        type = 0;
                        break;
                    case 7:
                        itemName = "Crown Helmet";
                        description = "A helmet fit for knight of the royalty.";
                        type = 2;
                        break;
                    case 8:
                        itemName = "Brass Gladius";
                        description = "A classic design.";
                        type = 0;
                        break;
                    case 9:
                        itemName = "Crystal Sword";
                        description = "A fine sword made from a high quality crystal.";
                        type = 0;
                        break;
                    case 10:
                        itemName = "Gourmet Steak";
                        description = "A steak with a layer of fungus. Gourmet they say...";
                        type = 3;
                        break;
                    case 11:
                        itemName = "Cookie";
                        description = "A vanilla cookie.";
                        type = 3;
                        break;
                    case 12:
                        itemName = "Scissor";
                        description = "A weird scissor.";
                        type = 2;
                        break;
                    case 13:
                        itemName = "Red berries";
                        description = "A bowl with red berries.";
                        type = 3;
                        break;
                    case 14:
                        itemName = "Pink Misture";
                        description = "";
                        type = 2;
                        break;
                    case 15:
                        itemName = "Bend Staff";
                        description = "I used to be a staff. Then it bend.";
                        type = 0;
                        break;
                    case 16:
                        itemName = "Poor Man's Staff";
                        description = "";
                        type = 0;
                        break;
                    case 17:
                        itemName = "Fire Arrow";
                        description = "";
                        type = 3;
                        break;
                    case 18:
                        itemName = "Big Hammer";
                        description = "";
                        type = 0;
                        break;
                    case 19:
                        itemName = "Spike Sword";
                        description = "";
                        type = 0;
                        break;
                    case 20:
                        itemName = "Royal Crown Hammer";
                        description = "A hammer fit for knight of the royalty.";
                        type = 0;
                        break;
                    case 21:
                        itemName = "Dark Red Cloak";
                        description = "Best of dark fashion.";
                        type = 1;
                        break;
                    case 22:
                        itemName = "Emerald Armor";
                        description = "A armor that is green. No emerald included.";
                        type = 1;
                        break;
                    case 23:
                        itemName = "Savage Sword";
                        description = "";
                        type = 0;
                        break;
                    case 24:
                        itemName = "Leather Helmet";
                        description = "A soldiers first helmet.";
                        type = 2;
                        break;
                    case 25:
                        itemName = "Chain Helmet";
                        description = "Improved Helmet.";
                        type = 2;
                        break;
                    #endregion

                    #region 26-50

                    case 26:
                        itemName = "Iron Helmet";
                        description = "";
                        type = 2;
                        break;
                    case 27:
                        itemName = "Emerald Iron Helmet";
                        description = "For fashion reasons.";
                        type = 2;
                        break;
                    case 28:
                        itemName = "Helmet with a Golden Crown";
                        description = "Don't know why.";
                        type = 2;
                        break;
                    case 29:
                        itemName = "Fruit Bowl";
                        description = "";
                        type = 3;
                        break;
                    case 30:
                        itemName = "Relic Wand";
                        description = "Seems old.";
                        type = 0;
                        break;
                    case 31:
                        itemName = "Currupted Wand";
                        description = "";
                        type = 0;
                        break;
                    case 32:
                        itemName = "---";
                        description = "---";
                        type = 4;
                        break;
                    case 33:
                        itemName = "Sapphire Wand";
                        description = "";
                        type = 0;
                        break;
                    case 34:
                        itemName = "Eternal Flower";
                        description = "";
                        type = 2;
                        break;
                    case 35:
                        itemName = "Golden Helmet";
                        description = "";
                        type = 2;
                        break;
                    case 36:
                        itemName = "Light Gladius";
                        description = "For more finese.";
                        type = 0;
                        break;
                    case 37:
                        itemName = "Emerald Axe";
                        description = "Emerald incluse.";
                        type = 0;
                        break;
                    case 38:
                        itemName = "Crown Light Armor";
                        description = "A armor fit for knight of the royalty. For hot summers.";
                        type = 1;
                        break;
                    case 39:
                        itemName = "Leather Armor";
                        description = "A soldiers first armor.";
                        type = 1;
                        break;
                    case 40:
                        itemName = "Chain Armor";
                        description = "Improved Armor.";
                        type = 1;
                        break;
                    case 41:
                        itemName = "Iron Armor";
                        description = "";
                        type = 1;
                        break;
                    case 42:
                        itemName = "Emerald Iron Armor";
                        description = "For fashion reasons.";
                        type = 1;
                        break;
                    case 43:
                        itemName = "Emerald with Golden Details";
                        description = "Don't know why.";
                        type = 1;
                        break;
                    case 44:
                        itemName = "Egg";
                        description = "Who came first?";
                        type = 3;
                        break;
                    case 45:
                        itemName = "Lapis Bow";
                        description = "";
                        type = 0;
                        break;
                    case 46:
                        itemName = "Iron Hammer";
                        description = "";
                        type = 1;
                        break;
                    case 47:
                        itemName = "Rubish Axe";
                        description = "";
                        type = 1;
                        break;
                    case 48:
                        itemName = "Crude Sword";
                        description = "";
                        type = 1;
                        break;
                    case 49:
                        itemName = "Big Galdius";
                        description = "";
                        type = 1;
                        break;
                    case 50:
                        itemName = "Green Rapier";
                        description = "";
                        type = 1;
                        break;
                    #endregion

                    #region 51-75

                    case 51:
                        itemName = "Giant Sword";
                        description = "";
                        type = 0;
                        break;
                    case 52:
                        itemName = "Iron Breast Plate";
                        description = "";
                        type = 1;
                        break;
                    case 53:
                        itemName = "Stone Axe";
                        description = "";
                        type = 0;
                        break;
                    case 54:
                        itemName = "Leather Pants";
                        description = "";
                        type = 2;
                        break;
                    case 55:
                        itemName = "Chain Legs";
                        description = "";
                        type = 2;
                        break;
                    case 56:
                        itemName = "Iron Legs";
                        description = "";
                        type = 2;
                        break;
                    case 57:
                        itemName = "Emerald Iron Legs";
                        description = "";
                        type = 2;
                        break;
                    case 58:
                        itemName = "Iron Legs with Golden Details";
                        description = "";
                        type = 2;
                        break;
                    case 59:
                        itemName = "Emerald";
                        description = "";
                        type = 2;
                        break;
                    case 60:
                        itemName = "Wierd Thing";
                        description = "";
                        type = 2;
                        break;
                    case 61:
                        itemName = "Holy Wand";
                        description = "";
                        type = 0;
                        break;
                    case 62:
                        itemName = "Wooden Mask";
                        description = "";
                        type = 2;
                        break;
                    case 63:
                        itemName = "Ronin's Katana";
                        description = "";
                        type = 0;
                        break;
                    case 64:
                        itemName = "Dragon Scale Armor";
                        description = "";
                        type = 1;
                        break;
                    case 65:
                        itemName = "White Oak Shield";
                        description = "";
                        type = 2;
                        break;
                    case 66:
                        itemName = "Bandana";
                        description = "";
                        type = 2;
                        break;
                    case 67:
                        itemName = "Dark Armor";
                        description = "";
                        type = 1;
                        break;
                    case 68:
                        itemName = "Green Robe";
                        description = "";
                        type = 1;
                        break;
                    case 69:
                        itemName = "Leather Boots";
                        description = "";
                        type = 2;
                        break;
                    case 70:
                        itemName = "Chain Boots";
                        description = "";
                        type = 2;
                        break;
                    case 71:
                        itemName = "Iron Boots";
                        description = "";
                        type = 2;
                        break;
                    case 72:
                        itemName = "Emerald Iron Boots";
                        description = "";
                        type = 2;
                        break;
                    case 73:
                        itemName = "Iron Boots with Golden Detail";
                        description = "";
                        type = 2;
                        break;
                    case 74:
                        itemName = "Feather and Book";
                        description = "";
                        type = 2;
                        break;
                    case 75:
                        itemName = "Custom Bow";
                        description = "";
                        type = 1;
                        break;
                    #endregion

                    #region 76-100
                    case 76:
                        itemName = "Pistol";
                        description = "Boomstick";
                        break;
                    case 77:
                        itemName = "Dark Red Armor";
                        description = "";
                        break;
                    case 78:
                        itemName = "Crude Katana";
                        description = "";
                        break;
                    case 79:
                        itemName = "Royal Rapier";
                        description = "";
                        break;
                    case 80:
                        itemName = "Green Singlet";
                        description = "";
                        break;
                    case 81:
                        itemName = "Bood Rapier";
                        description = "";
                        break;
                    case 82:
                        itemName = "Royal Halberd";
                        description = "";
                        break;
                    case 83:
                        itemName = "Training Sword";
                        description = "";
                        break;
                    case 84:
                        itemName = "Survivalist Sword";
                        description = "";
                        break;
                    case 85:
                        itemName = "Big Katana";
                        description = "";
                        break;
                    case 86:
                        itemName = "Crystal Claymore";
                        description = "";
                        break;
                    case 87:
                        itemName = "Golden Claymore";
                        description = "";
                        break;
                    case 88:
                        itemName = "Leather";
                        description = "Cow's Skin";
                        break;
                    case 89:
                        itemName = "Potato";
                        description = "";
                        break;
                    case 90:
                        itemName = "Slim Bow";
                        description = "";
                        break;
                    case 91:
                        itemName = "Pipe Pistol";
                        description = "Boomstick";
                        break;
                    case 92:
                        itemName = "Flower Wand";
                        description = "No flower included.";
                        break;
                    case 93:
                        itemName = "Blood Wand";
                        description = "";
                        break;
                    case 94:
                        itemName = "Royal Shield";
                        description = "";
                        break;
                    case 95:
                        itemName = "Star Sword";
                        description = "";
                        break;
                    case 96:
                        itemName = "Family Shield";
                        description = "";
                        break;
                    case 97:
                        itemName = "White Star";
                        description = "";
                        break;
                    case 98:
                        itemName = "Wooden Shovel";
                        description = "";
                        break;
                    case 99:
                        itemName = "Survivalist Shovel";
                        description = "";
                        break;
                    case 100:
                        itemName = "Iron Shovel";
                        description = "";
                        break;
                    #endregion

                    #region 101-125
                    case 101:
                        itemName = "Crystal Shovel";
                        description = "";
                        break;
                    case 102:
                        itemName = "Golden SHovel";
                        description = "";
                        break;
                    case 103:
                        itemName = "Saddle";
                        description = "";
                        break;
                    case 104:
                        itemName = "Pie";
                        description = "";
                        break;
                    case 105:
                        itemName = "Shotgun";
                        description = "Boomstick";
                        break;
                    case 106:
                        itemName = "Pirate Pistol";
                        description = "Boomstick";
                        break;
                    case 107:
                        itemName = "Crown Shield";
                        description = "A Shield fit for knight of the royalty.";
                        break;
                    case 108:
                        itemName = "Dark Red Shield";
                        description = "";
                        break;
                    case 109:
                        itemName = "Star Claymore";
                        description = "";
                        break;
                    case 110:
                        itemName = "Custom Helmet";
                        description = "There's holes on wrong place.";
                        break;
                    case 111:
                        itemName = "Blood Armor";
                        description = "";
                        break;
                    case 112:
                        itemName = "Carrot on a Fishing Rod";
                        description = "";
                        break;
                    case 113:
                        itemName = "Wooden Pickaxe";
                        description = "";
                        break;
                    case 114:
                        itemName = "Survivalist Pickaxe";
                        description = "";
                        break;
                    case 115:
                        itemName = "Iron Pickaxe";
                        description = "";
                        break;
                    case 116:
                        itemName = "Crystal Pickaxe";
                        description = "";
                        break;
                    case 117:
                        itemName = "Golden Pickaxe";
                        description = "";
                        break;
                    case 118:
                        itemName = "Raw T-Bone";
                        description = "";
                        break;
                    case 119:
                        itemName = "T-Bone";
                        description = "";
                        break;
                    case 120:
                        itemName = "Skull Helmet";
                        description = "";
                        break;
                    case 121:
                        itemName = "Oriental Pistol";
                        description = "Boomstinck, neh?";
                        break;
                    case 122:
                        itemName = "Green Cloak";
                        description = "";
                        break;
                    case 123:
                        itemName = "Teddy Bear";
                        description = "";
                        break;
                    case 124:
                        itemName = "Grimm Mask";
                        description = "";
                        break;
                    case 125:
                        itemName = "Spike Claymore";
                        description = "";
                        break;
                    #endregion

                    #region 126-150
                    case 126:
                        itemName = "Baked Fish";
                        description = "";
                        break;
                    case 127:
                        itemName = "Baked Potato";
                        description = "";
                        break;
                    case 128:
                        itemName = "Wooden Axe";
                        description = "";
                        break;
                    case 129:
                        itemName = "Survivalist Axe";
                        description = "";
                        break;
                    case 130:
                        itemName = "Iron Axe";
                        description = "";
                        break;
                    case 131:
                        itemName = "Crystal Axe";
                        description = "";
                        break;
                    case 132:
                        itemName = "Golden Axe";
                        description = "";
                        break;
                    case 133:
                        itemName = "Raw Ham";
                        description = "";
                        break;
                    case 134:
                        itemName = "Baked Ham";
                        description = "";
                        break;
                    case 135:
                        itemName = "Crown Armor";
                        description = "A Armor fit for knight of the royalty.";
                        break;
                    case 136:
                        itemName = "Fire Sword";
                        description = "";
                        break;
                    case 137:
                        itemName = "Tiara";
                        description = "";
                        break;
                    case 138:
                        itemName = "Crude Sword";
                        description = "";
                        break;
                    case 139:
                        itemName = "Raw Meat";
                        description = "";
                        break;
                    case 140:
                        itemName = "Steak";
                        description = "";
                        break;
                    case 141:
                        itemName = "Raw Fish";
                        description = "Sashimi";
                        break;
                    case 142:
                        itemName = "Golden Carrot";
                        description = "";
                        break;
                    case 143:
                        itemName = "Wooden Scythe";
                        description = "";
                        break;
                    case 144:
                        itemName = "Survivalyst Scythe";
                        description = "";
                        break;
                    case 145:
                        itemName = "Iron Scythe";
                        description = "";
                        break;
                    case 146:
                        itemName = "Crystal Scythe";
                        description = "";
                        break;
                    case 147:
                        itemName = "Golden Scythe";
                        description = "";
                        break;
                    case 148:
                        itemName = "Golden Watermelon";
                        description = "";
                        break;
                    case 149:
                        itemName = "Thing";
                        description = "";
                        break;
                    case 150:
                        itemName = "Lighter";
                        description = "";
                        break;
                    #endregion

                    #region 151-175
                    case 151:
                        itemName = "Flint";
                        description = "";
                        break;
                    case 152:
                        itemName = "Coal";
                        description = "";
                        break;
                    case 153:
                        itemName = "String";
                        description = "";
                        break;
                    case 154:
                        itemName = "Seeds";
                        description = "";
                        break;
                    case 155:
                        itemName = "Apple";
                        description = "";
                        break;
                    case 156:
                        itemName = "Golden Apple";
                        description = "";
                        break;
                    case 157:
                        itemName = "Duck Egg";
                        description = "Who came fir... Ah not chicken...";
                        break;
                    case 158:
                        itemName = "Ashes";
                        description = "";
                        break;
                    case 159:
                        itemName = "Pearl";
                        description = "";
                        break;
                    case 160:
                        itemName = "Potion";
                        description = "";
                        break;
                    case 161:
                        itemName = "Vial";
                        description = "";
                        break;
                    case 162:
                        itemName = "Medicine";
                        description = "";
                        break;
                    case 163:
                        itemName = "Yellow Mix";
                        description = "";
                        break;
                    case 164:
                        itemName = "Floral Green Powder";
                        description = "";
                        break;
                    case 165:
                        itemName = "Bow";
                        description = "";
                        break;
                    case 166:
                        itemName = "Brick";
                        description = "";
                        break;
                    case 167:
                        itemName = "Marble Brick";
                        description = "";
                        break;
                    case 168:
                        itemName = "Rice";
                        description = "";
                        break;
                    case 169:
                        itemName = "Wheat";
                        description = "";
                        break;
                    case 170:
                        itemName = "A Couple Portrait";
                        description = "Could be us, but...";
                        break;
                    case 171:
                        itemName = "Timber";
                        description = "";
                        break;
                    case 172:
                        itemName = "Bone";
                        description = "";
                        break;
                    case 173:
                        itemName = "Cake";
                        description = "";
                        break;
                    case 174:
                        itemName = "Mossy";
                        description = "";
                        break;
                    case 175:
                        itemName = "White Flask";
                        description = "";
                        break;
                    #endregion

                    #region 176-200
                    case 176:
                        itemName = "Wooden Box";
                        description = "";
                        break;
                    case 177:
                        itemName = "Coffee";
                        description = "";
                        break;
                    case 178:
                        itemName = "Floral Blue Powder";
                        description = "";
                        break;
                    case 179:
                        itemName = "Floral Red Powder";
                        description = "";
                        break;
                    case 180:
                        itemName = "Arrow";
                        description = "";
                        break;
                    case 181:
                        itemName = "Quiver";
                        description = "";
                        break;
                    case 182:
                        itemName = "Gold Ingot";
                        description = "";
                        break;
                    case 183:
                        itemName = "Gun Powder";
                        description = "";
                        break;
                    case 184:
                        itemName = "Bread";
                        description = "";
                        break;
                    case 185:
                        itemName = "Iridium";
                        description = "";
                        break;
                    case 186:
                        itemName = "Infinite Flask";
                        description = "";
                        break;
                    case 187:
                        itemName = "Monster Eye";
                        description = "";
                        break;
                    case 188:
                        itemName = "Infinite Pearl";
                        description = "";
                        break;
                    case 189:
                        itemName = "Fire Parl";
                        description = "";
                        break;
                    case 190:
                        itemName = "Gold Nugget";
                        description = "";
                        break;
                    case 191:
                        itemName = "Book";
                        description = "";
                        break;
                    case 192:
                        itemName = "Sapphire";
                        description = "";
                        break;
                    case 193:
                        itemName = "Floral White Powder";
                        description = "";
                        break;
                    case 194:
                        itemName = "Floral Black Powder";
                        description = "";
                        break;
                    case 195:
                        itemName = "Stick";
                        description = "";
                        break;
                    case 196:
                        itemName = "Cheese Maker";
                        description = "";
                        break;
                    case 197:
                        itemName = "Diamond";
                        description = "";
                        break;
                    case 198:
                        itemName = "Blood Dust";
                        description = "";
                        break;
                    case 199:
                        itemName = "Stone";
                        description = "";
                        break;
                    case 200:
                        itemName = "Papper";
                        description = "Papiro";
                        break;
                    #endregion

                    #region 201-225
                    case 201:
                        itemName = "Book";
                        description = "";
                        break;
                    case 202:
                        itemName = "Map";
                        description = "";
                        break;
                    case 203:
                        itemName = "Garlic";
                        description = "";
                        break;
                    case 204:
                        itemName = "Seeds";
                        description = "";
                        break;
                    case 205:
                        itemName = "Carrot";
                        description = "";
                        break;
                    case 206:
                        itemName = "Watermelon";
                        description = "";
                        break;
                    case 207:
                        itemName = "Purple Powder";
                        description = "";
                        break;
                    case 208:
                        itemName = "Ruby";
                        description = "";
                        break;
                    case 209:
                        itemName = "Orange Powder";
                        description = "";
                        break;
                    case 210:
                        itemName = "Improved Fishing Rod";
                        description = "";
                        break;
                    case 211:
                        itemName = "Dog Pod";
                        description = "";
                        break;
                    case 212:
                        itemName = "Wooden Bowl";
                        description = "";
                        break;
                    case 213:
                        itemName = "Soup";
                        description = "";
                        break;
                    case 214:
                        itemName = "Red Crystal";
                        description = "";
                        break;
                    case 215:
                        itemName = "Iron Bucket";
                        description = "";
                        break;
                    case 216:
                        itemName = "Water Bucket";
                        description = "";
                        break;
                    case 217:
                        itemName = "Lava Bucket";
                        description = "";
                        break;
                    case 218:
                        itemName = "Milk Bucket";
                        description = "";
                        break;
                    case 219:
                        itemName = "Black Fur";
                        description = "";
                        break;
                    case 220:
                        itemName = "Fire Essence";
                        description = "";
                        break;
                    case 221:
                        itemName = "Cocoa";
                        description = "";
                        break;
                    case 222:
                        itemName = "Lava Pearl";
                        description = "";
                        break;
                    case 223:
                        itemName = "";
                        description = "";
                        break;
                    case 224:
                        itemName = "";
                        description = "";
                        break;
                    case 225:
                        itemName = "";
                        description = "";
                        break;
                    #endregion

                    #region 226-250
                    case 226:
                        itemName = "";
                        description = "";
                        break;
                    case 227:
                        itemName = "";
                        description = "";
                        break;
                    case 228:
                        itemName = "";
                        description = "";
                        break;
                    case 229:
                        itemName = "";
                        description = "";
                        break;
                    case 230:
                        itemName = "";
                        description = "";
                        break;
                    case 231:
                        itemName = "";
                        description = "";
                        break;
                    case 232:
                        itemName = "";
                        description = "";
                        break;
                    case 233:
                        itemName = "";
                        description = "";
                        break;
                    case 234:
                        itemName = "";
                        description = "";
                        break;
                    case 235:
                        itemName = "";
                        description = "";
                        break;
                    case 236:
                        itemName = "";
                        description = "";
                        break;
                    case 237:
                        itemName = "";
                        description = "";
                        break;
                    case 238:
                        itemName = "";
                        description = "";
                        break;
                    case 239:
                        itemName = "";
                        description = "";
                        break;
                    case 240:
                        itemName = "";
                        description = "";
                        break;
                    case 241:
                        itemName = "";
                        description = "";
                        break;
                    case 242:
                        itemName = "";
                        description = "";
                        break;
                    case 243:
                        itemName = "";
                        description = "";
                        break;
                    case 244:
                        itemName = "";
                        description = "";
                        break;
                    case 245:
                        itemName = "";
                        description = "";
                        break;
                    case 246:
                        itemName = "";
                        description = "";
                        break;
                    case 247:
                        itemName = "";
                        description = "";
                        break;
                    case 248:
                        itemName = "";
                        description = "";
                        break;
                    case 249:
                        itemName = "";
                        description = "";
                        break;
                    case 250:
                        itemName = "";
                        description = "";
                        break;
                    #endregion

                    #region 251-275
                    case 251:
                        itemName = "";
                        description = "";
                        break;
                    case 252:
                        itemName = "";
                        description = "";
                        break;
                    case 253:
                        itemName = "";
                        description = "";
                        break;
                    case 254:
                        itemName = "";
                        description = "";
                        break;
                    case 255:
                        itemName = "";
                        description = "";
                        break;
                    case 256:
                        itemName = "";
                        description = "";
                        break;
                    case 257:
                        itemName = "";
                        description = "";
                        break;
                    case 258:
                        itemName = "";
                        description = "";
                        break;
                    case 259:
                        itemName = "";
                        description = "";
                        break;
                    case 260:
                        itemName = "";
                        description = "";
                        break;
                    case 261:
                        itemName = "";
                        description = "";
                        break;
                    case 262:
                        itemName = "";
                        description = "";
                        break;
                    case 263:
                        itemName = "";
                        description = "";
                        break;
                    case 264:
                        itemName = "";
                        description = "";
                        break;
                    case 265:
                        itemName = "";
                        description = "";
                        break;
                    case 266:
                        itemName = "";
                        description = "";
                        break;
                    case 267:
                        itemName = "";
                        description = "";
                        break;
                    case 268:
                        itemName = "";
                        description = "";
                        break;
                    case 269:
                        itemName = "";
                        description = "";
                        break;
                    case 270:
                        itemName = "";
                        description = "";
                        break;
                    case 271:
                        itemName = "";
                        description = "";
                        break;
                    case 272:
                        itemName = "";
                        description = "";
                        break;
                    case 273:
                        itemName = "";
                        description = "";
                        break;
                    case 274:
                        itemName = "";
                        description = "";
                        break;
                    case 275:
                        itemName = "";
                        description = "";
                        break;
                    #endregion

                    #region 276-300
                    case 276:
                        itemName = "";
                        description = "";
                        break;
                    case 277:
                        itemName = "";
                        description = "";
                        break;
                    case 278:
                        itemName = "";
                        description = "";
                        break;
                    case 279:
                        itemName = "";
                        description = "";
                        break;
                    case 280:
                        itemName = "";
                        description = "";
                        break;
                    case 281:
                        itemName = "";
                        description = "";
                        break;
                    case 282:
                        itemName = "";
                        description = "";
                        break;
                    case 283:
                        itemName = "";
                        description = "";
                        break;
                    case 284:
                        itemName = "";
                        description = "";
                        break;
                    case 285:
                        itemName = "";
                        description = "";
                        break;
                    case 286:
                        itemName = "";
                        description = "";
                        break;
                    case 287:
                        itemName = "";
                        description = "";
                        break;
                    case 288:
                        itemName = "";
                        description = "";
                        break;
                    case 289:
                        itemName = "";
                        description = "";
                        break;
                    case 290:
                        itemName = "";
                        description = "";
                        break;
                    case 291:
                        itemName = "";
                        description = "";
                        break;
                    case 292:
                        itemName = "";
                        description = "";
                        break;
                    case 293:
                        itemName = "";
                        description = "";
                        break;
                    case 294:
                        itemName = "";
                        description = "";
                        break;
                    case 295:
                        itemName = "";
                        description = "";
                        break;
                    case 296:
                        itemName = "";
                        description = "";
                        break;
                    case 297:
                        itemName = "";
                        description = "";
                        break;
                    case 298:
                        itemName = "";
                        description = "";
                        break;
                    case 299:
                        itemName = "";
                        description = "";
                        break;
                    case 300:
                        itemName = "";
                        description = "";
                        break;
                        #endregion


                }




            }
            catch (System.Exception)
            {
                Debug.Log("Error on Item.Load. ID not found or any other error.");
            }
        }
        else if (id == -1)
        {
            //empty slot
            itemName = "";
            description = "";
            sprite = Resources.Load<Sprite>("void");

        }
        else
        {
            Debug.Log("Invalid Item Id.");
        }

    }


}