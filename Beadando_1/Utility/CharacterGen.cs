using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class CharacterGen
    {
        public static Characters[] GetCharacters()
        {//alap karekterek létrehozása
            Characters[] chars;
            chars = new Characters[5];

            chars[0] = new Characters(3, 5, 200, 40, 24, "Character_1");
            chars[1] = new Characters(2, 7, 200, 40, 24, "Character_2");
            chars[2] = new Characters(4, 3, 210, 40, 24, "Character_3");
            chars[3] = new Characters(1, 8, 250, 40, 24, "Character_4");
            chars[4] = new Characters(2, 5, 220, 40, 24, "Character_5");

            return chars;
        }
    }
}
