import { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import { Currency } from './models/Currency';
import { Header } from 'semantic-ui-react';
import { CartesianGrid, Area, AreaChart, Tooltip, XAxis } from 'recharts';
import moment from 'moment';

function App() {
    const [currencies, setCurrencies] = useState<Currency[]>([]);

    useEffect(() => {
        axios.get<Currency[]>('https://localhost:7146/AlphaVantage')
            .then(response => {
                setCurrencies(response.data)
            })
    }, [])

    const formatXAxis = (tickItem : Date) => {
        return moment(tickItem).format("DD/MM");
    }

    return (
        <div>
            <Header as="h2" content='BTC to USD' />
            <AreaChart width={ 1200 } height={400} data={currencies} margin={{ top: 5, right: 20, left: 10, bottom: 5 }}>
                <XAxis dataKey="date" tickFormatter={(tick) => formatXAxis(tick)} />
                <Tooltip />
                <CartesianGrid stroke="#f5f5f5" />
                <Area type="monotone" dataKey="exchangeRate" stroke="#ff7300" yAxisId={0} />
            </AreaChart>
        </div>
    )
}

export default App;