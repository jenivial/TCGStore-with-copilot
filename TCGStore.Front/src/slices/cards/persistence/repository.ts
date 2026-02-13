import { Card } from '../domain/types';

const DEFAULT_API_BASE_URL = 'http://localhost:5005';

const getApiBaseUrl = () => {
    return (
        process.env.NEXT_PUBLIC_API_BASE_URL ||
        process.env.API_BASE_URL ||
        DEFAULT_API_BASE_URL
    );
};

const buildApiUrl = (path: string) => {
    const baseUrl = getApiBaseUrl().replace(/\/$/, '');
    return `${baseUrl}${path}`;
};

const fetchJson = async <T>(url: string, options?: RequestInit): Promise<T> => {
    console.log(`Fetching URL: ${url} with options:`, options);
    const response = await fetch(url, {
        ...options,
        headers: {
            'Content-Type': 'application/json',
            ...options?.headers,
        },
        cache: 'no-store',
    });

    if (!response.ok) {
        throw new Error(`Request failed with status ${response.status}`);
    }

    return (await response.json()) as T;
};

export class CardsRepository {
    async getAll(): Promise<Card[]> {
        return await fetchJson<Card[]>(buildApiUrl('/api/cards'));
    }

    async getById(id: string): Promise<Card | null> {
        try {
            return await fetchJson<Card>(buildApiUrl(`/api/cards/${encodeURIComponent(id)}`));
        } catch (error) {
            if (error instanceof Error && error.message.includes('404')) {
                return null;
            }
            throw error;
        }
    }
}
