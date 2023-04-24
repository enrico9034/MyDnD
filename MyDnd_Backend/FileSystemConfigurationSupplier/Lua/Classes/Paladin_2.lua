
function CheckRequirements()
    key, value = GetTableEntryValueKey(character.Class, "Paladin")
    if key == nil or value == nil then
        return false
    end
    
    return value.Level == 1 and character.Stats.Level > 1
end

function Calculate()
    character.AC = function(previusAC)
        return previusAC + 1
    end
    character.Class = function (previusClassTable)
        key, value = GetTableEntryValueKey(previusClassTable, "Paladin")
        
        previusClassTable[key].Level = 2
        previusClassTable[key].Description = "Now we are level 2"
        
        return previusClassTable
    end
end