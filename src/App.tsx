import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./components/Navbar.tsx";
import About from "./pages/About";
import Team from "./pages/Team";
import Events from "./pages/Events";

const App: React.FC = () => {
  return (
    <Router>
      <Navbar />

      <main style={{ padding: "1rem" }}>
        <div>
          <h1>Welcome to the NU IEEE Student Branch</h1>
          <p>Advancing technology for humanity</p>
        </div>

        <Routes>
          <Route path="/about" element={<About />} />
          <Route path="/team" element={<Team />} />
          <Route path="/events" element={<Events />} />
        </Routes>
      </main>
    </Router>
  );
};

export default App;
