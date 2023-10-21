import { LinkButton } from "@/components/link-button/link-button";
import type { EmployeeDto } from "@/types/employee-dto";
import { getAccessToken } from "@auth0/nextjs-auth0";
import jwt_decode from "jwt-decode";
import { withPageAuthRequired } from "@auth0/nextjs-auth0";
import { AddEmployee } from "@/components/add-employee/add-employee";
import { EmployeeList } from "@/components/employee-list/employee-list";

interface EmployeeWrapper {
  employees?: EmployeeDto[];
  success: boolean;
}

async function getEmployees(): Promise<EmployeeWrapper> {
  const { accessToken } = await getAccessToken();
  const res = await fetch(`${process.env.API_BASE_URL}/employees`, {
    headers: {
      Authorization: `Bearer ${accessToken}`,
    },
  });

  if (!res.ok) {
    return {
      success: false,
    };
  }

  return {
    success: true,
    employees: await res.json(),
  };
}

export default withPageAuthRequired(async function Employees() {
  const { accessToken } = await getAccessToken();
  const employeeWrapper = await getEmployees();

  function hasPermissionToWrite() {
    const decoded = jwt_decode(accessToken ?? "") as any;
    return decoded.permissions.indexOf("write:employees") !== -1;
  }

  return (
    <div className="flex min-h-full flex-1 flex-col justify-center px-6 py-12 lg:px-8">
      <div className="flex flex-col sm:mx-auto sm:w-full sm:max-w-sm gap-10 items-center">
        {!employeeWrapper.success ? (
          <p>Error fetching employees</p>
        ) : (
          <EmployeeList
            employees={employeeWrapper.employees}
            hasPermissionToWrite={hasPermissionToWrite()}
          />
        )}
        <LinkButton href="/">Go back</LinkButton>
      </div>
    </div>
  );
});
