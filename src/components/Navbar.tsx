import React from "react";
import { Link } from "react-router-dom";

const Navbar: React.FC = () => {
  return (
    <nav style={styles.nav}>
      <ul style={styles.ul}>
        <li style={styles.li}>
          <Link to="/about">About</Link>
        </li>
        <li style={styles.li}>
          <Link to="/team">Team</Link>
        </li>
        <li style={styles.li}>
          <Link to="/events">Events</Link>
        </li>
      </ul>
    </nav>
  );
};

const styles = {
  nav: {
    padding: "1rem",
    backgroundColor: "#007acc",
    color: "#fff",
  },
  ul: {
    display: "flex",
    listStyle: "none",
    margin: 0,
    padding: 0,
  },
  li: {
    marginRight: "1rem",
  },
};

export default Navbar;
