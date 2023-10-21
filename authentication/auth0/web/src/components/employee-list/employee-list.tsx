"use client";

import { EmployeeDto } from "@/types/employee-dto";
import { AddEmployee } from "../add-employee/add-employee";
import { useSWRResponse } from "@/utilities/use-swr-response";

interface EmployeeListProps {
  employees?: EmployeeDto[];
  hasPermissionToWrite: boolean;
}

export function EmployeeList(props: EmployeeListProps) {
  const { data, mutate } = useSWRResponse<EmployeeDto[]>(
    "/api/employees",
    props.employees
  );
  return (
    <>
      <ul role="list" className="divide-y divide-gray-100">
        {data?.map((employee) => (
          <li key={employee.id} className="flex justify-between gap-x-6 py-5">
            <div className="flex min-w-0 gap-x-4">
              <div className="min-w-0 flex-auto">
                <p className="text-sm font-semibold leading-6 text-gray-900">
                  {employee.fullName}
                </p>
                <p className="mt-1 truncate text-xs leading-5 text-gray-500">
                  {employee.title}
                </p>
              </div>
            </div>
          </li>
        ))}
      </ul>
      {props.hasPermissionToWrite && <AddEmployee mutate={mutate} />}
    </>
  );
}
