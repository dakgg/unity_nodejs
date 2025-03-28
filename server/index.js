import { getName } from './db.js';
import express, { json } from 'express';

const app = express();
const PORT = 3000;

app.use(json());

app.listen(PORT, () => {
    console.log(`Server running at http://localhost:${PORT}`);
});

app.post('/hello', (req, res) => {
    const name = req.body.name;
    const user = getName(1);
    res.json({ message: `Hello, ${name}!` });
});
