function CheckRequirements()
    local level = util:GetPlayerLevel()
    return level >= 2
end


function Calculate()
    util:EnablePowerSystem(Ki)
end
