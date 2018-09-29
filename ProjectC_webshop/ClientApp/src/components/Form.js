import React, { Component } from 'react';
import { FormControl, FormGroup, ControlLabel, HelpBlock, Button } from 'react-bootstrap';
import { Alert } from 'react-bootstrap';


export class Form extends React.Component {
    displayName = Form.name
    constructor(props, context) {
        super(props, context);

        this.handleChange = this.handleChange.bind(this);

        this.state = {
            value: ''
        };
    }

    getValidationState() {
        const length = this.state.value.length;
        if (length > 10) return 'success';
        else if (length > 5) return 'warning';
        else if (length > 0) return 'error';
        return null;
    }

    handleChange(e) {
        this.setState({ value: e.target.value });
    }

    render() {
        return (
            <form>
                <FormGroup
                    controlId="formBasicText"
                    validationState={this.getValidationState()}
                    
                >
                    <ControlLabel>Working example with validation</ControlLabel>
                    <FormControl
                        type="text"
                        value={this.state.value}
                        placeholder="Enter text"
                        onChange={this.handleChange}
                        
                    />
                    <FormControl.Feedback />
                    <HelpBlock>Validation is based on string length.</HelpBlock>
                </FormGroup>
            </form>


        );

    }
}

export class Form1 extends React.Component {
    displayName = Form1.name
    constructor(props, context) {
        super(props, context);

        this.handleChange = this.handleChange.bind(this);

        this.handleDismiss = this.handleDismiss.bind(this);
        this.handleShow = this.handleShow.bind(this);

        this.state = {
            value: '',
            value1: '',
            show: false,
            pressed: false
        };
    }


    handleDismiss() {
        this.setState({ show: false });
        this.setState({ pressed: false });
    }

    handleShow() {
        this.setState({ show: true });

    }

    getValidationState() {
        //const length = this.state.value.length;
        //if (this.state.pressed) {
        //    if (length > 10) return 'success';
        //    else if (length > 5) return 'warning';
        //    else if (length > 0) return 'error';
        //    return null;
        //}

        const User = this.state.value;
        const Pass = this.state.value1;
        if (this.state.pressed) {
            
            if (User === "" && Pass !==  "") { return this.handleShow() }
            else if (User !== '' && Pass === '') { return this.handleShow() }
            else if (User !== '' && Pass !== '') return null
        }
    }



    handleChange(e) {
        this.setState({ [e.target.name]: e.target.value }
        );
        this.setState({ pressed: false });
        console.log(this.state)
    }

    onSubmit = e => {
        // geeft log in f12 developer mode Console weer wat er gebeurt        
        console.log(this.state)
        this.setState({ pressed: true });

    };


    render() {

        if (this.state.show) {
            return (
                < Alert bsStyle="danger" onDismiss={this.handleDismiss} >
                    <h4>Oh snap! You got an error!</h4>
                    <p>
                        You need to fill in your Username AND your Password, hide alert to try again
          </p>
                    <p>
                        <Button bsStyle="danger">Take this action</Button>
                        <span> or </span>
                        <Button onClick={this.handleDismiss}>Hide Alert</Button>
                    </p>
                </Alert >
            );
        }



        return (
            <form>
                <FormGroup
                    controlId="formBasicText"
                    validationState={this.getValidationState()
                    }

                >
                    <ControlLabel>Password</ControlLabel>
                    <FormControl
                        name="value"
                        type="password"
                        value={this.state.value}
                        placeholder=" Password"
                        onChange={this.handleChange}

                    />
                    <FormControl.Feedback />
                    <HelpBlock>Fill in your password</HelpBlock>

                    <ControlLabel>Username</ControlLabel>
                    <FormControl
                        name="value1"
                        type="text"
                        value={this.state.value1}
                        placeholder=" Username"
                        onChange={this.handleChange}

                    />
                    <FormControl.Feedback />
                    <HelpBlock>Fill in your username</HelpBlock>

                </FormGroup>
                <Button
                    bsSize='large'
                    onClick={e => this.onSubmit(e)}> Submit </Button>
            </form>
        )
    }





}
