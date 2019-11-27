using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class CharacterBuilderDirector
{
    public static ICharacter Construct(ICharacterBuilder builder)
    {
        builder.AddCharacterAttr();
        builder.AddCharacterObject();
        builder.AddCharacterWeapon();
        builder.AddInCharacterSystem();
        return builder.GetResult();


    }

}