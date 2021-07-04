import React from "react";
import { BurgerStyled } from "./Burger.Styled";

export type Props = {
  open: boolean;
  setOpen: (v: boolean) => void;
};

const Burger = (props: Props) => (
  <BurgerStyled open={props.open} onClick={() => props.setOpen(!props.open)}>
    <div />
    <div />
    <div />
  </BurgerStyled>
);

export default Burger;
