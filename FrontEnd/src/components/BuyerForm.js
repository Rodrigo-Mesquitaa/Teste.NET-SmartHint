import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getBuyerById, createBuyer, updateBuyer } from '../services/buyerService';

const BuyerForm = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [buyer, setBuyer] = useState({
        name: '',
        email: '',
        phone: '',
        type: 'Física',
        cpfCnpj: '',
        stateRegistration: '',
        exempt: false,
        gender: '',
        birthDate: '',
        isBlocked: false,
        password: '',
    });

    useEffect(() => {
        if (id) {
            const fetchBuyer = async () => {
                try {
                    const data = await getBuyerById(id);
                    setBuyer(data);
                } catch (error) {
                    console.error('Erro ao buscar comprador:', error);
                }
            };

            fetchBuyer();
        }
    }, [id]);

    const handleChange = (event) => {
        const { name, value, type, checked } = event.target;
        setBuyer(prevState => ({
            ...prevState,
            [name]: type === 'checkbox' ? checked : value,
        }));
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            if (id) {
                await updateBuyer(id, buyer);
            } else {
                await createBuyer(buyer);
            }
            navigate('/');
        } catch (error) {
            console.error('Erro ao salvar comprador:', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h1>{id ? 'Editar Cliente' : 'Adicionar Cliente'}</h1>
            <label>
                Nome/Razão Social:
                <input
                    type="text"
                    name="name"
                    value={buyer.name}
                    onChange={handleChange}
                    required
                />
            </label>
            <label>
                E-mail:
                <input
                    type="email"
                    name="email"
                    value={buyer.email}
                    onChange={handleChange}
                    required
                />
            </label>
            <label>
                Telefone:
                <input
                    type="text"
                    name="phone"
                    value={buyer.phone}
                    onChange={handleChange}
                    required
                />
            </label>
            <label>
                Tipo de Pessoa:
                <select
                    name="type"
                    value={buyer.type}
                    onChange={handleChange}
                    required
                >
                    <option value="Física">Física</option>
                    <option value="Jurídica">Jurídica</option>
                </select>
            </label>
            <label>
                CPF/CNPJ:
                <input
                    type="text"
                    name="cpfCnpj"
                    value={buyer.cpfCnpj}
                    onChange={handleChange}
                    required
                />
            </label>
            {buyer.type === 'Jurídica' && (
                <>
                    <label>
                        Inscrição Estadual:
                        <input
                            type="text"
                            name="stateRegistration"
                            value={buyer.stateRegistration}
                            onChange={handleChange}
                        />
                    </label>
                    <label>
                        Isenção:
                        <input
                            type="checkbox"
                            name="exempt"
                            checked={buyer.exempt}
                            onChange={handleChange}
                        />
                    </label>
                </>
            )}
            {buyer.type === 'Física' && (
                <>
                    <label>
                        Gênero:
                        <select
                            name="gender"
                            value={buyer.gender}
                            onChange={handleChange}
                            required
                        >
                            <option value="">Selecione</option>
                            <option value="Feminino">Feminino</option>
                            <option value="Masculino">Masculino</option>
                            <option value="Outro">Outro</option>
                        </select>
                    </label>
                    <label>
                        Data de Nascimento:
                        <input
                            type="date"
                            name="birthDate"
                            value={buyer.birthDate}
                            onChange={handleChange}
                            required
                        />
                    </label>
                </>
            )}
            <label>
                Bloqueado:
                <input
                    type="checkbox"
                    name="isBlocked"
                    checked={buyer.isBlocked}
                    onChange={handleChange}
                />
            </label>
            <label>
                Senha:
                <input
                    type="password"
                    name="password"
                    value={buyer.password}
                    onChange={handleChange}
                    required
                />
            </label>
            <button type="submit">{id ? 'Atualizar' : 'Adicionar'}</button>
        </form>
    );
};

export default BuyerForm;
