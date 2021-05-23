USE [PR_r0236874]
Insert Into[Foodies].[LevelPreperation]
([Level])
VALUES
('Easy'),('Medium'),('Expert');

Insert Into[Foodies].[Preperationtime]
([RangeMinutes])
VALUES
('0-15'),('15-30'),('15-45'),('30-60'),('+1hour');

Insert Into[Foodies].[Category]
([Name],[ParentId])
VALUES
('Breads, Muffins & Scones',null),('Breakfast',null),('Desserts',null),('Dinner',null),('Dips, Salad, Dressings, Salsas and Sauces',null),('Drinks',null),
('Lunch',null),('Main Course',null),('One Pot Meal',null),('Pancakes',null),('Quesadillas and Sandwiches',null),('Salades',null),('Side Dishes',null),('Snacks',null),
('Soups, Stews & Chili',null),('Veggie',null)