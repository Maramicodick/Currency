import { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import { Currency } from './models/Currency';
import { Header } from 'semantic-ui-react';
import { CartesianGrid, Line, LineChart, Tooltip, XAxis } from 'recharts';

function App() {
    const [currencies, setCurrencies] = useState<Currency[]>([]);

    useEffect(() => {
        axios.get<Currency[]>('https://localhost:7146/AlphaVantage')
            .then(response => {
                setCurrencies(response.data)
            })
    }, [])

    return (
        <div>
            <Header as="h2" content='BTC to USD' />
            <LineChart width={400} height={400} data={currencies.map(currency => (currency.exchangeRate))} margin={{ top: 5, right: 20, left: 10, bottom: 5 }}>
                <XAxis dataKey="BTC" />
                <Tooltip />
                <CartesianGrid stroke="#f5f5f5" />
                <Line type="monotone" dataKey="uv" stroke="#ff7300" yAxisId={0} />
                <Line type="monotone" dataKey="pv" stroke="#387908" yAxisId={1} />
            </LineChart>
        </div>
    )
}

export default App;