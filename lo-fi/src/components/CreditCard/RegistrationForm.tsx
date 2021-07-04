import { useState } from "react";

// Registration Form functional component
export const RegistrationForm = (callback: any, initialState = {}) => {
    const [values, setValues] = useState(initialState);

    // onChange
    const onChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setValues({ ...values, [event.target.name]: event.target.value });

        if(event.target.name == "creditCardNumber"){
            if (event.target.value.length > 16 || event.target.value.length < 12) {
                console.log("Not a valid Credit Card")
            } else {
                console.log(event.target.value)
            }
        } else if(event.target.name == "cvc") {
            if (event.target.value.length != 3) {
                console.log("Not a valid CVC")
            } else {
                console.log(event.target.value)
            }
        } else if(event.target.name == "expiryMonth") {
            if (event.target.value.length > 2 || Number(event.target.value) > 12) {
                console.log("Not a valid Expiry Month")
            } else {
                console.log(event.target.value)
            }
        } else if(event.target.name == "expiryYear") {
            if (event.target.value.length > 4) {
                console.log("Not a valid Expiry Year")
            } else {
                console.log(event.target.value)
            }
        }
    };

     // onSubmit
     const onSubmit = (event: React.FormEvent<HTMLFormElement>) => {

        const creditCardNumber  = (event.currentTarget.elements.namedItem('creditCardNumber') as HTMLInputElement).value
        const cvc               = (event.currentTarget.elements.namedItem('cvc') as HTMLInputElement).value
        const expiryMonth       = (event.currentTarget.elements.namedItem('expiryMonth') as HTMLInputElement).value
        const expiryYear        = (event.currentTarget.elements.namedItem('expiryYear') as HTMLInputElement).value

        console.log( "Credit Card Number :: " + creditCardNumber);
        console.log( "CVC :: " + cvc);
        console.log( "Expiry :: " + new Date(Number(expiryYear), Number(expiryMonth), 1));
        
        event.preventDefault();
    };

    // return values
    return {
        onChange,
        onSubmit,
        values,
    };
}