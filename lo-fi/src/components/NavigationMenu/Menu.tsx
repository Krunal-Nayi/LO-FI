import React, { useState, useRef } from "react";

import Burger from "../NavigationMenu/Burger";
import { StyledMenu, StyledLink } from "./Menu.Styled";

import { useOnClickOutside } from "../../hooks";

const Menu = () => {
  const [open, setOpen] = useState<boolean>(false);
  const node = useRef<HTMLDivElement>(null);
  const close = () => setOpen(false);

  useOnClickOutside(node, () => setOpen(false));

  return (
    <div ref={node}>
      <StyledMenu open={open}>
        <StyledLink onClick={() => close()}>Home</StyledLink>
        <StyledLink onClick={() => close()}>This is menu content</StyledLink>
      </StyledMenu>
      <Burger open={open} setOpen={setOpen} />
    </div>
  );
};

export default Menu;
