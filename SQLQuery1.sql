SELECT * FROM Recipe;

SELECT * FROM Ingredient;

SELECT a.Name from Ingredient a
INNER JOIN RecipeIngredient b ON a.Id = b.IngredientId
WHERE b.RecipeId = 6;

UPDATE Recipe SET Name = 'Popeyes Chicken Sandwich'
WHERE Id = 5;

INSERT INTO Recipe 
VALUES ('Pizza', 20, 'Cook it.');

DELETE FROM Recipe
WHERE Id = 8;