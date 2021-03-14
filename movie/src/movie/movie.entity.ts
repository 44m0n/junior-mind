import { Entity, Column, PrimaryGeneratedColumn } from 'typeorm';

@Entity()
export class MovieEntity {
    @PrimaryGeneratedColumn()
    Id: number;

    @Column()
    Title: string;

    @Column()
    ReleaseDate: Date;

    @Column()
    Genre: string;

    @Column()
    Price: number;
}