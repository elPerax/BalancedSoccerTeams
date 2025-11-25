
# Balanced Soccer Team Generator

Final project for **ASP.NET Core MVC** – Fall 2025.

This web application helps a coach create **fair and competitive soccer teams** by
using each player’s skill profile. The system calculates an overall rating and
rank for every player, then generates balanced teams so that the total skill of
each team is as close as possible.

---

## 🎯 Main Features

- **Player Management (CRUD)**
  - Add, edit, view, and delete players.
  - Each player stores 5 skill attributes:
    - Ball Control
    - Passing Accuracy
    - Dribbling
    - Defensive Awareness
    - Shooting

- **Overall Score & Ranking**
  - The app computes an **OverallScore** for every player based on the 5 skills.
  - Each player is assigned a **Rank (1–5)** according to this score.

- **Balanced Team Generator**
  - Coach enters the **number of teams** (between 2 and 10).
  - Coach selects which players are **present** using a checkbox list.
  - The system distributes players into teams using a **snake-draft algorithm**,
    keeping total skill scores as balanced as possible.
  - Output shows:
    - Each team
    - Players per team
    - Team total skill score

- **Modern UI**
  - Custom Bootstrap-based styling.
  - Clean navigation: **Home**, **Players**, **Team Generator**, **Privacy**.
  - Responsive cards and tables for use during a real practice or game.

---

## 🧠 How the Ranking Works

Each player has 5 skills on a scale from **1 to 10**.

The **overall score** is the *average* of those five values:

\[
\text{OverallScore} = \frac{
    \text{BallControl} +
    \text{PassingAccuracy} +
    \text{Dribbling} +
    \text{DefensiveAwareness} +
    \text{Shooting}
}{5}
\]

The **Rank** is then assigned from 1 to 5 using score thresholds, for example:

- 8.5 – 10.0 → Rank 1 (top players)
- 7.5 – 8.4 → Rank 2
- 6.5 – 7.4 → Rank 3
- 5.5 – 6.4 → Rank 4
- below 5.5 → Rank 5

This ranking helps the coach quickly see the relative level of each player.

---

## 🧮 How the Team Balancing Algorithm Works

1. Take the list of **selected players only** (those checked by the coach).
2. Sort them by **OverallScore (descending)** so the strongest players come first.
3. Use a **snake draft** over the teams:
   - First round: Team 1 → Team 2 → … → Team *n*
   - Second round: Team *n* → … → Team 2 → Team 1
   - Repeat until all players are assigned.

This approach spreads strong and weaker players across all teams, keeping the
**total skill score** of each team close to the others without being completely
random.

---

## 🛠️ Tech Stack

- **Framework:** ASP.NET Core 8 MVC
- **Language:** C#
- **Data Access:** Entity Framework Core 8
- **Database (local):** SQL Server LocalDB
- **UI:** Bootstrap 5 + custom CSS
- **IDE:** Visual Studio 2022

---

## 🚀 Running the Project Locally

1. **Clone the repository**

   ```bash
   git clone https://github.com/<your-username>/BalancedSoccerTeams.git
   cd BalancedSoccerTeams
