
function Calculate()
    isProficient = character.Skills.Acrobatics.IsProficient
    if isProficient then
        return character.Stats.Strength.Modifier + character.ProficiencyModificator.Value
    else
        return character.Stats.Strength.Modifier
    end
end
