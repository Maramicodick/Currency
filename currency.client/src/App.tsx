import { useEffect, useState } from 'react';
import './layout/styles.css';
import axios from 'axios';
import { GraphCurrency } from './app/models/GraphCurrency';
import { CartesianGrid, Area, AreaChart, Tooltip, XAxis } from 'recharts';
import moment from 'moment';
import NavBar from './app/layout/NavBar';
import { Container, Header } from 'semantic-ui-react';
import { LiveCurrency } from './app/models/LiveCurrency';
import CurrencyDashboard from './features/currencies/dashboard/CurrencyDashboard';

function App() {
    const [graphCurrencies, setGraphCurrencies] = useState<GraphCurrency[]>([]);
    const [curr, setCurr] = useState<LiveCurrency>();

    useEffect(() => {
        axios.get<LiveCurrency>('https://localhost:7146/AlphaVantage/alpha')
            .then(response => {
                setCurr(response.data)
            })
    })

    useEffect(() => {
        axios.get<GraphCurrency[]>('https://localhost:7146/AlphaVantage')
            .then(response => {
                setGraphCurrencies(response.data)
            })
    }, [])

    const formatXAxis = (tickItem : Date) => {
        return moment(tickItem).format("DD/MM");
    }

    return (
        <div>
            <NavBar />
            <Header as='h2' content={graphCurrencies.find((currency) => currency.date == Date.now.toString()) ? curr?.exchangeRate : curr?.exchangeRate} />
            <Container style={{marginTop: '7em'} }>
                <CurrencyDashboard currencies={currencies} />
                <AreaChart width={ 1200 } height={400} data={graphCurrencies} margin={{ top: 5, right: 20, left: 10, bottom: 5 }}>
                    <XAxis dataKey="date" tickFormatter={(tick) => formatXAxis(tick)} />
                    <Tooltip />
                    <CartesianGrid stroke="#f5f5f5" />
                    <Area type="monotone" dataKey="exchangeRate" stroke="#ff7300" yAxisId={0} />
                </AreaChart>
            </Container>    
        </div>
    )
}

export default App;