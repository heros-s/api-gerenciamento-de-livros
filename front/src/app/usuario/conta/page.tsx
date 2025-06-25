"use client";

import React, { useEffect, useState } from "react";
import { Container, Paper, Typography, Box } from "@mui/material";
import { useRouter } from "next/navigation";
import Usuario from "@/app/types/usuario";



export default function MinhaConta() {
  const [usuario, setUsuario] = useState<Usuario[]>([]);
  const router = useRouter();

  useEffect(() => {
    const token = localStorage.getItem("token");

    async function carregarUsuario() {
      try {
        const resposta = await fetch("http://localhost:5249/api/usuario/conta", {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        });

        if (!resposta.ok) {
          router.push("/");
          return;
        }

        const dados = await resposta.json();
        setUsuario(dados);
      } catch (error) {
        console.error("Erro ao buscar dados do usuário", error);
        router.push("/");
      }
    }

    carregarUsuario();
  }, []);

  return (
    <Container maxWidth="sm" sx={{ mt: 6 }}>
      <Paper elevation={5} sx={{ p: 4 }}>
        <Typography variant="h5" gutterBottom>
          Minha Conta
        </Typography>
        {usuario && (
          <Box>
            <Typography variant="body1"><strong>Nome:</strong></Typography>
            <Typography variant="body1"><strong>Email:</strong></Typography>
          </Box>
        )}
      </Paper>
    </Container>
  );
}
