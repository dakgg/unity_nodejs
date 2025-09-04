import express from "express";

const app = express();
const PORT = 3000;

app.get("/", (req, res) => {
  res.send("Hello Express!");
});

app.get('/ping', (req, res) => {
    res.send('Pong');
});

app.listen(PORT, () => {
  console.log(`서버 실행 중 → http://localhost:${PORT}`);
});