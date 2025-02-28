<?php
    require __DIR__ . '/../../db/db_connect.php';

    header('Content-Type: application/json');

    $input = json_decode(file_get_contents('php://input'), true);

    if (!isset($input['recipeID']) || !isset($input['ingredientID']) || !isset($input['field']) || !isset($input['newValue'])) {
        echo json_encode(['success' => false, 'error' => 'Missing recipeID, ingredientID, field, or newValue']);
        exit;
    }

    $recipeID = $input['recipeID'];
    $ingredientID = $input['ingredientID'];
    $field = $input['field'];
    $newValue = $input['newValue'];

    try {
        $query = "UPDATE recipe_ingredients SET $field = :newValue WHERE recipeID = :recipeID AND ingredientID = :ingredientID";
        $params = [
            ':newValue' => $newValue,
            ':recipeID' => $recipeID,
            ':ingredientID' => $ingredientID
        ];
        $result = UpdateData($query, $params);

        if ($result) {
            echo json_encode(['success' => true]);
        } else {
            echo json_encode(['success' => false, 'error' => 'Failed to update ingredient']);
        }
    } catch (PDOException $e) {
        echo json_encode(['success' => false, 'error' => $e->getMessage()]);
    }
?>