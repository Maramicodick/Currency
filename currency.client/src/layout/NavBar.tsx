import { Button, Container, Menu } from "semantic-ui-react";

export default function NavBar() {
    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item header>
                    Currencies
                </Menu.Item>
                <Menu.Item name='Currencies' />
                <Menu.Item>
                    <Button positive content='About' />
                </Menu.Item>
            </Container>
        </Menu>
    )
}