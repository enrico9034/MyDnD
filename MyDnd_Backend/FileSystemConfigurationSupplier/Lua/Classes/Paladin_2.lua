
function CheckRequirements()
    for key, value in pairs(character.Class) do
        if type(value) == "table" then
            if value.Name == "Paladin" then
                return value.Level == 1 and character.Stats.Level == 2
            end
        end
    end
    
    return false
end

function Calculate()
    character.AC = function(previusAC)
        return previusAC + 1
    end
    character.Class = function (previusClassTable)
        for key, value in pairs(previusClassTable) do
            if type(value) == "table" then
                if value.Name == "Paladin" then
                    previusClassTable[key].Level = 2
                    previusClassTable[key].Description = "Now we are level 2"
                end
            end
        end
        return previusClassTable
    end
end