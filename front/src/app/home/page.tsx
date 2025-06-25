"use client";

import { List, ListItem, ListItemButton, ListItemText, Paper, Typography } from "@mui/material";
import Link from "next/link";

function Menu() {
  return (
    <Paper elevation={8} sx={{ width: 300, padding: 2 }}>
      <Typography variant="h6" gutterBottom>
        Menu de Navegação
      </Typography>
      <List>
        <ListItem disablePadding>
          <ListItemButton component={Link} href="/">
            <ListItemText primary="Início" />
          </ListItemButton>
        </ListItem>

        <ListItem disablePadding>
          <ListItemButton component={Link} href="/usuario/login">
            <ListItemText primary="Login" />
          </ListItemButton>
        </ListItem>

        <ListItem disablePadding>
          <ListItemButton component={Link} href="/usuario/conta">
            <ListItemText primary="Minha Conta" />
          </ListItemButton>
        </ListItem>

      </List>
    </Paper>
  );
}

export default Menu;
