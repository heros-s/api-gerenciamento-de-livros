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
import Autor from "@/app/types/autor";

function ListarAutor() {

    const [Autores, setAutor] = useState<Autor[]>([]);

    useEffect(() => {
        api
        .get<Livro[]>("/autor/listar")
        .then((resposta) => {
            setAutor(resposta.data);
            console.table(resposta.data);
        })
        .catch((erro) => {
            console.error(erro);
        });
    }, []);


    return (
        <Container maxWidth="md" sx={{ mt: 4 }}>
      <Typography variant="h4" component="h1" gutterBottom>
        Listar Autores
      </Typography>
      <TableContainer component={Paper} elevation={10}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>#</TableCell>
              <TableCell>Nome</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {Autores.map((Autor) => (
              <TableRow key={Autor.id}>
                <TableCell>
                  <Link href={`/livros/${Autor.id}`} color="inherit">
                    {Autor.id}
                  </Link>
                </TableCell>
                <TableCell>{Autor.nome}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Container>
    );

}

export default ListarAutor;