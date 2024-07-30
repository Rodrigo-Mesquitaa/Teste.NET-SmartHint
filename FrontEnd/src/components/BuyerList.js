import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { getBuyers } from '../services/buyerService';

const BuyerList = () => {
    const [buyers, setBuyers] = useState([]);
    const [page, setPage] = useState(1);
    const [search, setSearch] = useState('');

    useEffect(() => {
        const fetchBuyers = async () => {
            try {
                const data = await getBuyers(page, search);
                setBuyers(data.results);
            } catch (error) {
                console.error('Erro ao buscar compradores:', error);
            }
        };

        fetchBuyers();
    }, [page, search]);

    const handleSearchChange = (event) => {
        setSearch(event.target.value);
    };

    const handleSearchSubmit = (event) => {
        event.preventDefault();
        setPage(1); // Resetar para a primeira página ao pesquisar
    };

    return (
        <div>
            <h1>Consulte os seus Clientes cadastrados na sua Loja ou realize o cadastro de novos Clientes</h1>
            <Link to="/add">
                <button>Adicionar Cliente</button>
            </Link>
            <form onSubmit={handleSearchSubmit}>
                <input
                    type="text"
                    value={search}
                    onChange={handleSearchChange}
                    placeholder="Pesquisar..."
                />
                <button type="submit">Filtrar</button>
            </form>
            <table>
                <thead>
                    <tr>
                        <th>Checkbox</th>
                        <th>Nome/Razão Social</th>
                        <th>E-mail</th>
                        <th>Telefone</th>
                        <th>Data de Cadastro</th>
                        <th>Bloqueado</th>
                        <th>Ações</th>
                    </tr>
                </thead>
                <tbody>
                    {buyers.map(buyer => (
                        <tr key={buyer.id}>
                            <td><input type="checkbox" /></td>
                            <td>{buyer.name}</td>
                            <td>{buyer.email}</td>
                            <td>{buyer.phone}</td>
                            <td>{new Date(buyer.birthDate).toLocaleDateString()}</td>
                            <td><input type="checkbox" checked={buyer.isBlocked} readOnly /></td>
                            <td>
                                <Link to={`/edit/${buyer.id}`}>
                                    <button>Editar</button>
                                </Link>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <div>
                {/* Adicione a lógica de paginação aqui */}
            </div>
        </div>
    );
};

export default BuyerList;
