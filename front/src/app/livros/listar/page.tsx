"use client";

import api from "@/app/services/api";
import Livro from "@/app/types/livro";
import { useEffect, useState } from "react";
import {
  Container,
  Typography,
  TableContainer,
  Paper,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  TablePagination,
  Link,
} from "@mui/material";

function ListarLivros() {

    const [livros, setLivros] = useState<Livro[]>([]);

    useEffect(() => {
        api
        .get<Livro[]>("/livro/listar")
        .then((resposta) => {
            setLivros(resposta.data);
            console.table(resposta.data);
        })
        .catch((erro) => {
            console.error(erro);
        });
    }, []);


    return (
        <Container maxWidth="md" sx={{ mt: 4 }}>
      <Typography variant="h4" component="h1" gutterBottom>
        Listar Livros
      </Typography>
      <TableContainer component={Paper} elevation={10}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>#</TableCell>
              <TableCell>Nome</TableCell>
              <TableCell>Genero</TableCell>
              <TableCell>autor</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {livros.map((livro) => (
              <TableRow key={livro.id}>
                <TableCell>
                  <Link href={`/livros/${livro.id}`} color="inherit">
                    {livro.id}
                  </Link>
                </TableCell>
                <TableCell>{livro.nome}</TableCell>
                <TableCell>{livro.genero}</TableCell>
                <TableCell>{livro.autor}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Container>
    );

}

export default ListarLivros;