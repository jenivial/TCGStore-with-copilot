import { NextResponse } from 'next/server';
import { getCatalogItems } from '../handlers';

export async function GET(request: Request) {
    try {
        const items = await getCatalogItems();
        return NextResponse.json(items);
    } catch (error) {
        return NextResponse.error();
    }
}