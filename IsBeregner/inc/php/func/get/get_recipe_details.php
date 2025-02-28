<?php
    require __DIR__ . '/../../db/db_connect.php';

    session_start();

    header('Content-Type: application/json');

    try {
        if (!isset($_GET['recipeID']) || !filter_var($_GET['recipeID'], FILTER_VALIDATE_INT)) {
            throw new Exception('Invalid or missing recipe ID');
        }

        $recipeID = (int)$_GET['recipeID'];

        $stmt = $pdo->prepare('SELECT * FROM Recipes WHERE RecipeID = :recipeID');
        $stmt->bindParam(':recipeID', $recipeID, PDO::PARAM_INT);
        $stmt->execute();
        $recipe = $stmt->fetch(PDO::FETCH_ASSOC);

        if (!$recipe) {
            throw new Exception('Recipe not found');
        }

        $stmt = $pdo->prepare('
            SELECT i.ingredientID, i.name, ri.amount, i.sugar, i.fat, i.femt, i.drymatter,
                   i.total_drymatter, i.water, i.price_per_kilo, i.price
            FROM recipe_ingredients ri
            JOIN ingredients i ON ri.ingredientID = i.ingredientID
            WHERE ri.recipeID = :recipeID
        ');
        $stmt->bindParam(':recipeID', $recipeID, PDO::PARAM_INT);
        $stmt->execute();
        $ingredients = $stmt->fetchAll(PDO::FETCH_ASSOC);

        $recipe['ingredients'] = $ingredients;

        echo json_encode(['success' => true, 'data' => $recipe]);

    } catch (Exception $e) {
        http_response_code(400);
        echo json_encode(['success' => false, 'error' => $e->getMessage()]);
    } catch (PDOException $e) {
        http_response_code(500);
        echo json_encode(['success' => false, 'error' => 'Database error occurred']);
        error_log('Database error: ' . $e->getMessage());
    }
?>
