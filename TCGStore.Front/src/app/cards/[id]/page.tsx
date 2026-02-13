import Link from 'next/link';
import { notFound } from 'next/navigation';
import { CardsHandler } from '@/slices/cards/handlers';
import { CardDetails } from '@/slices/cards/ui/components';

type CardDetailsPageProps = {
    params: Promise<{ id: string }>;
};

const CardDetailsPage = async ({ params }: CardDetailsPageProps) => {
    const { id } = await params;
    const handler = new CardsHandler();
    const card = await handler.getCardById(id);

    if (!card) {
        notFound();
    }

    return (
        <section className="page">
            <Link className="btn btn--ghost" href="/cards">
                Back to cards
            </Link>
            <CardDetails card={card} />
        </section>
    );
};

export default CardDetailsPage;