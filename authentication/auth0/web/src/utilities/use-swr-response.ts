import useSWR from "swr";

async function fetcher(url: string) {
  const response = await fetch(url);
  return response.json();
}

export function useSWRResponse<T>(key: string, initialData?: any) {
  return useSWR<T>(key, fetcher, {
    fallbackData: initialData,
  });
}
