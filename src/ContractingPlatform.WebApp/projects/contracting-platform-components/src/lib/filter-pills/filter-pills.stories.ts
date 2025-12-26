import type { Meta, StoryObj } from '@storybook/angular';
import { FilterPills } from './filter-pills';

const meta: Meta<FilterPills> = {
  title: 'Components/FilterPills',
  component: FilterPills,
  tags: ['autodocs'],
  argTypes: {
    options: {
      control: 'object',
      description: 'Array of filter options',
    },
    selectedId: {
      control: 'text',
      description: 'Currently selected option ID',
    },
    multiple: {
      control: 'boolean',
      description: 'Allow multiple selections',
    },
  },
};

export default meta;
type Story = StoryObj<FilterPills>;

const projectFilterOptions = [
  { id: 'all', label: 'All' },
  { id: 'residential', label: 'Residential' },
  { id: 'commercial', label: 'Commercial' },
  { id: 'kitchen', label: 'Kitchen' },
  { id: 'bathroom', label: 'Bathroom' },
  { id: 'basement', label: 'Basement' },
  { id: 'restoration', label: 'Restoration' },
  { id: 'exterior', label: 'Exterior' },
];

export const ProjectFilter: Story = {
  args: {
    options: projectFilterOptions,
    selectedId: 'all',
    multiple: false,
  },
};

export const ServiceFilter: Story = {
  args: {
    options: [
      { id: 'all', label: 'All Services' },
      { id: 'renovation', label: 'Renovation' },
      { id: 'restoration', label: 'Restoration' },
      { id: 'construction', label: 'Construction' },
    ],
    selectedId: 'all',
    multiple: false,
  },
};

export const BoroughFilter: Story = {
  args: {
    options: [
      { id: 'all', label: 'All Boroughs' },
      { id: 'manhattan', label: 'Manhattan' },
      { id: 'brooklyn', label: 'Brooklyn' },
      { id: 'queens', label: 'Queens' },
      { id: 'bronx', label: 'Bronx' },
      { id: 'staten', label: 'Staten Island' },
    ],
    selectedId: 'all',
    multiple: false,
  },
};

export const MultipleSelection: Story = {
  args: {
    options: projectFilterOptions,
    selectedIds: ['kitchen', 'bathroom'],
    multiple: true,
  },
};
