import Link from 'next/link';
import { CardsHandler } from '@/slices/cards/handlers';
import { CardsList } from '@/slices/cards/ui/components';
import { Card } from '@/slices/cards/domain/types';

const CardsPage = async () => {
    const handler = new CardsHandler();
    let cards: Card[] = [];
    let errorMessage = '';

    try {
        cards = await handler.getAllCards();
    } catch (error) {
        errorMessage = error instanceof Error ? error.message : 'Failed to load cards.';
    }

    return (
        <section className="page">
            <div className="page__header">
                <div>
                    <p className="eyebrow">Cards Catalog</p>
                    <h1>Browse the collection</h1>
                    <p className="subtle">
                        Pulling from the backend cards endpoint to keep this list fresh.
                    </p>
                </div>
                <Link className="btn" href="/">
                    Back to home
                </Link>
            </div>
            {errorMessage ? (
                <div className="callout error">{errorMessage}</div>
            ) : (
                <CardsList cards={cards} />
            )}
        </section>
    );
};

export default CardsPage;
