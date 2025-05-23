<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Under Construction</title>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&display=swap" rel="stylesheet">
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: 'Poppins', sans-serif;
            background: linear-gradient(rgba(0,0,0,0.6), rgba(0,0,0,0.6)), 
                        url('https://images.unsplash.com/photo-1504384308090-c894fdcc538d?auto=format&fit=crop&w=1920&q=80') no-repeat center center/cover;
            color: #ffffff;
            height: 100vh;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            text-align: center;
            padding: 20px;
        }

        h1 {
            font-size: 48px;
            font-weight: 600;
            margin-bottom: 20px;
        }

        p {
            font-size: 20px;
            max-width: 600px;
            margin-bottom: 30px;
        }

        .button {
            background: #f1a840;
            color: white;
            padding: 12px 28px;
            font-size: 16px;
            border: none;
            border-radius: 8px;
            text-transform: uppercase;
            cursor: pointer;
            transition: background 0.3s ease;
        }

        .button:hover {
            background: #d88d2a;
        }

        .loader {
            margin: 30px auto;
            border: 6px solid #f3f3f3;
            border-top: 6px solid #f1a840;
            border-radius: 50%;
            width: 60px;
            height: 60px;
            animation: spin 1.2s linear infinite;
        }

        @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
        }

        @media (max-width: 600px) {
            h1 {
                font-size: 32px;
            }
            p {
                font-size: 16px;
            }
        }
    </style>
</head>
<body>

    <h1>🚧 We're Coming Soon!</h1>
    <p>Our website is currently under construction. We're working hard to give you a better experience. Stay tuned!</p>
    <div class="loader"></div>
    <!-- <button class="button" onclick="window.location.href='mailto:contact@yourdomain.com'">Contact Us</button> -->

</body>
</html>
