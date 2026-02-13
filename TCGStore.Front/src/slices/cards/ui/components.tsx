import Link from 'next/link';
import React from 'react';
import { Card } from '../domain/types';

const formatPrice = (price: number) => {
    return new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
    }).format(price);
};

const formatDate = (value: string) => {
    const date = new Date(value);
    if (Number.isNaN(date.getTime())) {
        return value;
    }
    return date.toLocaleDateString('en-US', {
        year: 'numeric',
        month: 'short',
        day: 'numeric',
    });
};

export const CardsList = ({ cards }: { cards: Card[] }) => {
    return (
        <div className="cards-list">
            {cards.map((card) => (
                <Link key={card.id} href={`/cards/${card.id}`} className="card-tile">
                    <div className="card-tile__meta">{card.setName}</div>
                    <h3 className="card-tile__title">{card.name}</h3>
                    <p className="card-tile__rarity">{card.rarity}</p>
                    <div className="card-tile__footer">
                        <span className="card-tile__price">{formatPrice(card.price)}</span>
                        <span className="card-tile__collector">#{card.collectorNumber}</span>
                    </div>
                </Link>
            ))}
        </div>
    );
};

export const CardDetails = ({ card }: { card: Card }) => {
    return (
        <article className="card-detail">
            <header className="card-detail__header">
                <div>
                    <p className="card-detail__set">{card.setName}</p>
                    <h1>{card.name}</h1>
                    <p className="card-detail__meta">
                        {card.rarity} · #{card.collectorNumber}
                    </p>
                </div>
                <div className="card-detail__price">{formatPrice(card.price)}</div>
            </header>
            <div className="card-detail__body">
                <div className="card-detail__image">
                    {card.imageUrl ? (
                        // eslint-disable-next-line @next/next/no-img-element
                        <img src={card.imageUrl} alt={card.name} />
                    ) : (
                        <div className="card-detail__placeholder">No image</div>
                    )}
                </div>
                <div className="card-detail__content">
                    <p className="card-detail__description">
                        {card.description || 'No description available.'}
                    </p>
                    <dl className="card-detail__facts">
                        <div>
                            <dt>Set code</dt>
                            <dd>{card.setCode || 'N/A'}</dd>
                        </div>
                        <div>
                            <dt>Created</dt>
                            <dd>{formatDate(card.createdAt)}</dd>
                        </div>
                        <div>
                            <dt>Updated</dt>
                            <dd>{formatDate(card.updatedAt)}</dd>
                        </div>
                    </dl>
                </div>
            </div>
        </article>
    );
};
