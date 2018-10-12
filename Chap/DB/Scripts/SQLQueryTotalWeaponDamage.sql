SELECT Character.name, 
       WeaponModel.name, 
	   (AVG(WeaponModel.max_damage) + 
	    SUM(JewelModel.added_damage * WeaponJewelMatch.match_factor * JewelCutQuality.factor)) 
	   AS total_weapon_damage
FROM Character,
     WeaponModel,
	 Weapon,
	 JewelModel,
	 Jewel,
	 JewelCutQuality,
	 WeaponJewelMatch
WHERE ((Character.weapon_left = Weapon.id) OR (Character.weapon_right = Weapon.id))
  AND Weapon.weapon_model_id = WeaponModel.id
  AND Jewel.weapon_id = Weapon.id
  AND Jewel.jewel_model_id = JewelModel.id
  AND WeaponJewelMatch.jewel_model_id = JewelModel.id
  AND WeaponJewelMatch.weapon_model_id = WeaponModel.id
  AND JewelCutQuality.cut_quality = Jewel.cut_quality
GROUP BY Character.name, WeaponModel.name