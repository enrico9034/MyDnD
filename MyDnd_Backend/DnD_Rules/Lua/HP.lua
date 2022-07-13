function CheckRequirements()
	return true
end

function Calculate()
	ConstitutionModificator = character.Stats.Constitution.Modifier
	return 10 + ConstitutionModificator
end
