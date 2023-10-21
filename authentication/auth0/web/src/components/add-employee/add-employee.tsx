"use client";

import { EmployeeDto } from "@/types/employee-dto";
import { EmployeeInputModel } from "@/types/employee-input-model";
import { KeyedMutator } from "swr";

interface AddEmployeeProps {
  mutate: KeyedMutator<EmployeeDto[]>;
}

export function AddEmployee(props: AddEmployeeProps) {
  async function addEmployee(): Promise<void> {
    const dummy: EmployeeInputModel = {
      fullName: "Dummy",
      title: "Hoax",
    };

    await fetch("/api/employees", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(dummy),
    });

    props.mutate();
  }

  return (
    <button
      onClick={() => addEmployee()}
      className="inline-flex items-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50"
    >
      Add
    </button>
  );
}
