import styled from "styled-components";
import { colors } from "../../globalStyle";

export const BurgerStyled = styled.button<{ open: boolean }>`
  position: fixed;
  left: 3vw;
  top: 3vw;
  width: 2rem;
  height: 2rem;
  padding: 0;
  background: transparent;

  display: flex;
  flex-direction: column;
  justify-content: space-around;

  border: none;
  cursor: pointer;
  outline: none;
  z-index: 1;

  @media (max-width: 600px) {
    right: ${({ open }) => (open ? "initial" : "3vw")};
    left: ${({ open }) => (open ? "initial" : "2vw" )};
  }

  div {
      position: relative;
      width: 2rem;
      height: 0.25rem;
      border-radius: 10px;
      transition: all 0.3s linear;
      transform-origin: 1px;
      background-color: ${({ open }) =>
        open ? colors.pearl : colors.lightbrown};

      :first-child {
        transform: ${({ open }) => (open ? "rotate(35deg)" : "rotate(0)")};
        top:  ${({ open }) => (open ? "10px" : "0")};
      }

      :nth-child(2) {
        transform: ${({ open }) => (open ? "translateX(20px)" : "translateX(0)")};
      }

      :nth-child(3) {
        transform: ${({ open }) => (open ? "rotate(-35deg)" : "rotate(0)")};
        top:  ${({ open }) => (open ? "-10px" : "0")};
      }
  }
`;
