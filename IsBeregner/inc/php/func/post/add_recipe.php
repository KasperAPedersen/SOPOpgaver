<?php
    session_start();

    require __DIR__ . '/../../db/db_connect.php';

    header('Content-Type: application/json');

    $input = json_decode(file_get_contents('php://input'), true);

    if (!isset($input['name']) || !isset($_SESSION['user_id'])) {
        echo json_encode(['success' => false, 'error' => 'Missing name or user ID']);
        exit;
    }

    $name = $input['name'];
    $userID = $_SESSION['user_id'];

    try {
        $query = "INSERT INTO recipes (UserID, Title) VALUES (:userID, :name)";
        $params = [
            ':userID' => $userID,
            ':name' => $name
        ];
        $result = UpdateData($query, $params);

        if ($result) {
            echo json_encode(['success' => true]);
        } else {
            echo json_encode(['success' => false, 'error' => 'Failed to add recipe']);
        }
    } catch (PDOException $e) {
        echo json_encode(['success' => false, 'error' => $e->getMessage()]);
    }
?>