import React from 'react';
import { Grid, Row } from 'react-bootstrap';

const layout = (props) => {
    return (
        <Grid>
            <Row>
                This is the place for navigation component.
            </Row>
            <main>
                { props.children }
            </main>
        </Grid>
    )
}
export default layout