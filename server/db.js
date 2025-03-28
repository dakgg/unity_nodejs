// db.js
import Database from 'better-sqlite3';
const db = new Database('mydb.sqlite');

// 테이블 만들기
db.prepare(`
  CREATE TABLE IF NOT EXISTS users (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT,
    age INTEGER
  )
`).run();

// 데이터 삽입
db.prepare('INSERT INTO users (name, age) VALUES (?, ?)').run('Alice', 30);

// 데이터 조회
const rows = db.prepare('SELECT * FROM users').all();
console.log(rows);


export function getName(id) {
    const stmt = db.prepare('SELECT * FROM users WHERE ID  = ?');
    const user = stmt.get(id);
    return user.name;
}