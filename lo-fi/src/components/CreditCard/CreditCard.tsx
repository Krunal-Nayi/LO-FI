import React, { useState } from "react";
import { RegistrationForm } from "./RegistrationForm";

const RegisterCreditCard = () => {
    // defining the initial state for the form
    const userName: string = "John Doe"
    const initialState = {
        creditCardNumber: "",
        cvc: "",
        expiryMonth: "",
        expiryYear: ""
    };

    // getting the event handlers from our custom form
    const { onChange, onSubmit, values } = RegistrationForm(
        registerCardUserCallback,
        initialState
    );

    // a submit function that will execute upon form submission
    function registerCardUserCallback() {
        // send "values" to database
    }

    return (
        <div className="jumbotron jumbotron-fluid">
            <div className="container">
                <div className="row">
                    <div className="col-md-12 customName p-5">
                        <h1>Welcome {userName}</h1>
                    </div>
                </div>
            </div>
            <div className="container">
                <form onSubmit={onSubmit} className="needs-validation">
                    <div className="form-group">
                        <input
                            className="form-control"
                            name='creditCardNumber'
                            id='creditCardNumber'
                            placeholder='Credit Card Number'
                            type="number" 
                            pattern="[0-9]{12,16}*"
                            onChange={onChange}
                            required
                        />
                    </div>
                    <div className="form-group row d-flex justify-content-end">
                        <div className="col-md-3 w-25 p-3">
                            <input
                                className="form-control"
                                name='cvc'
                                id='cvc'
                                type="number" 
                                pattern="[0-9]{3}*"
                                placeholder='CVC'
                                onChange={onChange}
                                required
                            />
                        </div>
                        <div className="col-md-4 w-50 p-3 d-flex justify-content-end">
                            <input
                                className="form-control w-50"
                                name='expiryMonth'
                                id='expiryMonth'
                                type="number" 
                                pattern="[0-9]{2}*"
                                placeholder='Month'
                                onChange={onChange}
                                required
                            />
                            <input
                                className="form-control w-50"
                                name='expiryYear'
                                id='expiryYear'
                                type="number" 
                                pattern="[0-9]{2}*"
                                placeholder='Year'
                                onChange={onChange}
                                required
                            />
                        </div>
                    </div>
                    <button type='submit' className="btn btn-primary btn-lg btn-block">Submit</button>
                </form>
            </div>
        </div>
    );
}

export default RegisterCreditCard;