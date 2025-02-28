<?php

    require __DIR__ . '/../../db/db_connect.php';

    header('Content-Type: application/json');

    try {
        $query = "SELECT ingredientID, name FROM ingredients";
        $result = GetData($query);

        echo json_encode(['success' => true, 'data' => $result]);
    } catch (PDOException $e) {
        echo json_encode(['success' => false, 'error' => $e->getMessage()]);
    }

?>