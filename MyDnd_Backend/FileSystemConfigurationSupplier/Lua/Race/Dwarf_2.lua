function CheckRequirements()
    local level = character.Stats.Level
    return level >= 2
end


function Calculate()
    character.Stats.Dexterity = character.Stats.Dexterity + 2
end
