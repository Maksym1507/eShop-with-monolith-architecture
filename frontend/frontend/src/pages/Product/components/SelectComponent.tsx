import React from "react";

type Props = {
  options: any,
  value: any,
  onChange: any
}

const SelectComponent = (props: Props) => {
  return (
    <select value={props.value} onChange={(event) => props.onChange(event?.target.value)}>
      {props.options.map((option: any) => (
        <option key={option.value} value={option.value}>{option.name}</option>
      ))}
    </select>
  );
};

export default SelectComponent;
