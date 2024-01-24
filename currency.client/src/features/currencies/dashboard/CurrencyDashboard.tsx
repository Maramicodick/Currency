import { Grid, List } from 'semantic-ui-react';
import { Currency } from '../../../app/models/Currency'

interface Props {
    currencies: Currency[];
}

export default function CurrencyDashboard({currencies}: Props) {
    return (
        <Grid>
            <Grid.Column width='10'>
                <List>
                    {currencies.map(currency => (
                        <List.Item key={currency.code}>
                            {currency.name}
                        </List.Item>
                    ))}
                </List>
            </Grid.Column>
        </Grid>
    )
}