<?php
    require __DIR__ . '/../../db/db_connect.php';

    if ($_SERVER['REQUEST_METHOD'] === 'POST') {
        $username = $_POST['username'];
        $password = $_POST['password'];

        // Check if the username already exists
        $stmt = $pdo->prepare('SELECT * FROM users WHERE username = ?');
        $stmt->execute([$username]);
        $user = $stmt->fetch();

        if ($user) {
            echo 'Username already taken';
        } else {
            $hashedPassword = password_hash($password, PASSWORD_DEFAULT);

            // Insert the new user into the database
            $stmt = $pdo->prepare('INSERT INTO users (username, password) VALUES (?, ?)');
            if ($stmt->execute([$username, $hashedPassword])) {
                header('Location: /login.html');
            } else {
                header('Location: /register.html');
            }
        }
    }
?>