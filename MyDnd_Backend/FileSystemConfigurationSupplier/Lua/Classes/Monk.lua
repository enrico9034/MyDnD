function CheckRequirements()
    if next(character.Class) == nil then -- The array is empty
        return true
    end
    return false
end

function Calculate()
    character.AC = function(previusAC)
        return previusAC + 1
    end
    character.Class = function (previusClassTable)
        table.insert(previusClassTable,
                {
                    Name = "Monk",
                    Level = 1
                })
        return previusClassTable
    end
end